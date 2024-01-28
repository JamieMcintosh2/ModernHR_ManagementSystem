using DevelopmentService.Models;

namespace DevelopmentService.Data
{
    public interface IDevelopmentRepo
    {
        IEnumerable<EmpFeedback> GetAllFeedback();
        IEnumerable<EmpFeedback> GetAllFeedbackWithPerformance();
        EmpFeedback GetFeedbackById(int id);
        void DeleteFeedback(EmpFeedback feedback);
        IEnumerable<EmpPerformance> GetAllPerformance();
        EmpPerformance GetPerformanceById(int id);

        void CreatePerformance(EmpPerformance performance);
        void DeletePerformance(EmpPerformance performance);
        void CreateFeedback(EmpFeedback feedback);

        IEnumerable<PerformanceHistory> GetPerformanceHistoryForEmployee(int empId);
        IEnumerable<FeedbackHistory> GetFeedbackHistoryForEmployee(int empId);
        void CreatePerformanceHistory(PerformanceHistory performanceHistory);
        void CreateFeedbackHistory(FeedbackHistory feedbackHistory);

        bool SaveChanges();
    }
}
