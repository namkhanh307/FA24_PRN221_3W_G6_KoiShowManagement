using KoiShowManagement.Repositories.Models;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Service
{
    public interface IScoreService
    {
        Task<bool> StartCalculatingScoresAsync();
        void StopCalculatingScores();
    }

    public class ScoreService : IScoreService
    {
        private readonly ILogger<ScoreService> _logger;
        private readonly PointOnProgressingService _pointOnprocessingService;
        private CancellationTokenSource _cancellationTokenSource;

        public ScoreService(ILogger<ScoreService> logger, PointOnProgressingService pointOnprocessingService)
        {
            _logger = logger;
            _pointOnprocessingService = pointOnprocessingService;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<bool> StartCalculatingScoresAsync()
        {
            var points = await _pointOnprocessingService.GetAll(); // Assume this method retrieves all points
            bool allScoresUpdated = true;

            foreach (var point in points)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    break;

                point.TotalScore = CalculateTotalScore(point);
                await _pointOnprocessingService.Update(point);
                await Task.Delay(5000);
                _logger.LogInformation($"Updated PointId {point.PointId} with TotalScore: {point.TotalScore}");

            
                if (point.TotalScore == null) 
                {
                    allScoresUpdated = false;
                }
            }

            return allScoresUpdated; 
        }

        public void StopCalculatingScores()
        {
            _cancellationTokenSource.Cancel();
        }

        private int? CalculateTotalScore(PointOnProgressing point)
        {
            if ((bool)point.IsDeleted)
            {
                return null; // or return 0 if you prefer
            }

            int shapeScore = point.ShapePoint ?? 0;
            int colorScore = point.ColorPoint ?? 0;
            int patternScore = point.PatternPoint ?? 0;
            int penaltyPoints = point.PenaltyPoints ?? 0;

            int totalScore = (shapeScore + colorScore + patternScore) - penaltyPoints;
            return totalScore < 0 ? 0 : totalScore;
        }
    }
}
