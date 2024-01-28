using DevelopmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentService.Data
{
    public class SqlDevelopmentRepo : IDevelopmentRepo
    {
        private readonly dbContext _context;

        public SqlDevelopmentRepo(dbContext context)
        {
            _context = context;
        }

        public void CreateFeedback(EmpFeedback fdback)
        {
            //If null throw error
            if (fdback == null)
            {
                throw new ArgumentNullException(nameof(fdback));
            }
            //Check if Performance selected exists
            var performanceExists = _context.performances.Any(p => p.EmpId == fdback.EmpId);
            Console.WriteLine(performanceExists.ToString());
            if(!performanceExists)
            {
                throw new ArgumentException("Performance Review does not exist. Performance Review must be created before feedback can be given", nameof(fdback.EmpId));
            }
            var existingFeedback = _context.feedbacks.FirstOrDefault(f => f.EmpId == fdback.EmpId);
            if (existingFeedback != null)
            {
                //throw new ArgumentException("Feedback with the same EmpId already exists.", nameof(feedback.EmpId));
                FeedbackHistory history = new FeedbackHistory { EmployeeId = existingFeedback.EmpId, Feedback = existingFeedback.feedback, OverallScore = existingFeedback.overallScore, FeedbackDate = existingFeedback.feedbackDate };
                //Call method to add data to history table
                CreateFeedbackHistory(history);
                //Call method to delete current data from the table which is now in the history table
                DeleteFeedback(existingFeedback);
                //Add new data to current table
                _context.feedbacks.Add(fdback);

            }
            else
            {
                _context.feedbacks.Add(fdback);
            }


        }

        
        public void CreateFeedbackHistory(FeedbackHistory feedbackHistory)
        {
            if (feedbackHistory == null)
            {
                throw new ArgumentNullException(nameof(feedbackHistory));
            }

            _context.historicalFeedback.Add(feedbackHistory);
            _context.SaveChanges();
        }

        public void CreatePerformance(EmpPerformance performance)
        {
            //If null throw error
            if (performance == null)
            {
                throw new ArgumentNullException(nameof(performance));
            }
            var existingPerformance = _context.performances.FirstOrDefault(p => p.EmpId == performance.EmpId);
            if (existingPerformance != null)
            {

                //When a new Performance review is created move the Current Review for the employee to the history table, and update current with the new Performance review

                //Create History obj to hold current performance data
                PerformanceHistory history = new PerformanceHistory { EmployeeId = existingPerformance.EmpId, Strengths = existingPerformance.strengths, Weaknesses = existingPerformance.weaknesses, ReviewDate = existingPerformance.reviewDate };
                //Call method to add data to the history table
                CreatePerformanceHistory(history);
                //Delete the data from current performance table
                DeletePerformance(existingPerformance);
                //Add the new passed in data to the Current Performance table
                _context.performances.Add(performance);
            }
            //Else emp passed in is not null or already has a performance review, add it
            else
            {
                _context.performances.Add(performance);
            }
        }

        public void CreatePerformanceHistory(PerformanceHistory performanceHistory)
        {
            if (performanceHistory == null)
            {
                throw new ArgumentNullException(nameof(performanceHistory));
            }

            _context.historicalPerformance.Add(performanceHistory);
            _context.SaveChanges();
        }

        public void DeleteFeedback(EmpFeedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback));
            }
            else
            {
                _context.feedbacks.Remove(feedback);
            }
        }

        public void DeletePerformance(EmpPerformance performance)
        {
            if (performance == null)
            {
                throw new ArgumentNullException(nameof(performance));
            }
            else
            {
                _context.performances.Remove(performance);
            }
        }

        public IEnumerable<EmpFeedback> GetAllFeedback()
        {
            return _context.feedbacks.ToList();
        }

        public IEnumerable<EmpFeedback> GetAllFeedbackWithPerformance()
        {
            return _context.feedbacks.ToList();
        }

        public IEnumerable<EmpPerformance> GetAllPerformance()
        {
            return _context.performances.ToList();
        }

        public EmpFeedback GetFeedbackById(int id)
        {
            return _context.feedbacks.FirstOrDefault(p => p.EmpId == id);
        }

        public IEnumerable<FeedbackHistory> GetFeedbackHistoryForEmployee(int empId)
        {
            return _context.historicalFeedback
            .Where(history => history.EmployeeId == empId)
            .ToList();
        }

        public EmpPerformance GetPerformanceById(int id)
        {
            return _context.performances.FirstOrDefault(p => p.EmpId == id);
        }

        public IEnumerable<PerformanceHistory> GetPerformanceHistoryForEmployee(int Id)
        {
            return _context.historicalPerformance
                .Where(history => history.EmployeeId == Id)
                .ToList();
        }

        public bool SaveChanges()
        {
                        //This method saves the changes in the database without this the changes wont be saved
            return (_context.SaveChanges() >= 0);
        }
    }
}
