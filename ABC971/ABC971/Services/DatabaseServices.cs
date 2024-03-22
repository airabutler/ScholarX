using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ABC971.Models;
using Xamarin.Essentials;

namespace ABC971.Services
{
    public static class DatabaseServices
    {
        private static SQLiteAsyncConnection dbs;


        public static async Task Init()
        {
            if (dbs != null)  
            {                 
                return;
            }

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ABC971.db");

            dbs = new SQLiteAsyncConnection(dbPath);

            await dbs.CreateTableAsync<Term>();
            await dbs.CreateTableAsync<Course>();
            await dbs.CreateTableAsync<Assessment>();
        }

        //Term CRUD Services

        #region TERM Database Services


        public static async Task AddTerm(string name, string status, DateTime start, DateTime end)
        {
            await Init();
            Term term = new Term()
            {
                Name = name,
                Status = status,
                StartDate = start,
                EndDate = end
            };

            await dbs.InsertAsync(term);

            int id = term.ID;
        }

        public static async Task DeleteTerm(int id)
        {
            await Init();

            await dbs.DeleteAsync<Term>(id);

        }

        public static async Task<IEnumerable<Term>> GetTerms()
        {
            await Init();

            var terms = await dbs.Table<Term>().ToListAsync();
            return terms;
        }

        public static async Task UpdateTerm(int id, string name, string status, DateTime start, DateTime end)
        {
            await Init();
           

            Term termQuery = await dbs.Table<Term>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();

            if (termQuery != null)
            {
                termQuery.Name = name;
                termQuery.Status = status;
                termQuery.StartDate = start;
                termQuery.EndDate = end;

                await dbs.UpdateAsync(termQuery);
            }

        }



        #endregion
        //CRUD Services


        #region COURSE Database Services


        public static async Task AddCourse(int termId, string name, string status, DateTime startDate, DateTime endDate,
            bool alert, string instructorName, string instructorPhone, string instructorEmail, string notes)
        {
            await Init();
            Course course = new Course()
            {
                TermID = termId,
                Name = name,
                Status = status,
                StartDate = startDate,
                EndDate = endDate,
                Alert = alert,
                InstructorName = instructorName,
                InstructorPhone = instructorPhone,
                InstructorEmail = instructorEmail,
                Notes = notes
            };

            await dbs.InsertAsync(course);

            int id = course.ID;
        }

        public static async Task DeleteCourse(int id)
        {
            await Init();

            await dbs.DeleteAsync<Course>(id);
        }

        public static async Task<IEnumerable<Course>> GetCourses(int termId)
        {
            await Init();

            var courses = await dbs.Table<Course>().Where(x => x.TermID == termId).ToListAsync();
            return courses;


        }

        public static async Task<IEnumerable<Course>> GetCourses()
        {
            await Init();

            var courses = await dbs.Table<Course>().ToListAsync();
            return courses;
        }

        public static async Task UpdateCourse(int courseId, string name, string status, DateTime startDate, DateTime endDate,
            bool alert, string instructorName, string instructorPhone, string instructorEmail, string notes)
        {
            await Init();

            var courseQuery = await dbs.Table<Course>().Where(x => x.ID == courseId).FirstOrDefaultAsync();

            if (courseQuery != null)
            {
                courseQuery.Name = name;
                courseQuery.Status = status;
                courseQuery.StartDate = startDate;
                courseQuery.EndDate = endDate;
                courseQuery.Alert = alert;
                courseQuery.InstructorName = instructorName;
                courseQuery.InstructorPhone = instructorPhone;
                courseQuery.InstructorEmail = instructorEmail;
                courseQuery.Notes = notes;

                await dbs.UpdateAsync(courseQuery);

            }

        }
        #endregion

        // DATABASES SERVICES 

        #region ASSESSMENT DATABASE SERVICES
        public static async Task AddAssessment(int courseId, string name, string type, DateTime startDate, DateTime dueDate, bool alert)
        {
            await Init();

            Assessment assessment = new Assessment()
            {
                CourseID = courseId,
                Name = name,
                Type = type,
                StartDate = startDate,
                DueDate = dueDate,
                Alert = alert

            };

            await dbs.InsertAsync(assessment);
            int id = assessment.ID;
        }

        public static async Task UpdateAssessment(int assessmentId, string name, string type, DateTime startDate, DateTime dueDate, bool alert)
        {
            await Init();

            var assessQuery = await dbs.Table<Assessment>().Where(x => x.ID == assessmentId).FirstOrDefaultAsync();

            if (assessQuery != null)
            {
                assessQuery.Name = name;
                assessQuery.Type = type;
                assessQuery.StartDate = startDate;
                assessQuery.DueDate = dueDate;
                assessQuery.Alert = alert;

                await dbs.UpdateAsync(assessQuery);
            }

        }

        public static async Task DeleteAssessment(int id)
        {
            await Init();
            await dbs.DeleteAsync<Assessment>(id);
        }

        public static async Task<IEnumerable<Assessment>> GetAssessments(int courseId)
        {
            await Init();
            var assessments = await dbs.Table<Assessment>().Where(x => x.CourseID == courseId).ToListAsync();
            return assessments;
        }

        public static async Task<IEnumerable<Assessment>> GetAssessments()
        {
            await Init();

            var assessments = await dbs.Table<Assessment>().ToListAsync();
            return assessments;
        }



        #endregion

        #region METHODS FOR SAMPLE DATA


        public static async Task LoadSampleData()
        {
            await Init();

            Term sampleTerm1 = new Term
            {
                Name = "TERM 2",
                Status = "PASSED",
                StartDate = DateTime.Today.Date,
                EndDate = DateTime.Today.AddMonths(6)
            };

            await dbs.InsertAsync(sampleTerm1);

            Course sampleCourse1 = new Course
            {
                TermID = sampleTerm1.ID,
                Name = "C971 Mobile Application Development",
                Status = "Passed",
                StartDate = DateTime.Today.Date,
                EndDate = DateTime.Today.Date.AddDays(24),
                Alert = true,
                InstructorName = "Macy Rogers",
                InstructorPhone = "682-357-3949",
                InstructorEmail = "macy@wgu.edu",
                Notes = "Complete App Required"
            };

            await dbs.InsertAsync(sampleCourse1);

            Assessment sampleAssessment1 = new Assessment
            {
                CourseID = sampleCourse1.ID,
                Name = "Mobile Application Development PA",
                Type = "Performance",
                StartDate = DateTime.Today.Date,
                DueDate = DateTime.Today.Date.AddDays(16),
                Alert = true
            };

            await dbs.InsertAsync(sampleAssessment1);

            Assessment sampleAssessment2 = new Assessment
            {
                CourseID = sampleCourse1.ID,
                Name = "Mobile Application Development OA",
                Type = "Objective",
                StartDate = DateTime.Today.Date,
                DueDate = DateTime.Today.Date.AddDays(10),
                Alert = true
            };

            await dbs.InsertAsync(sampleAssessment2);


        }

        public static async Task ClearSampleData()
        {
            await Init();

            await dbs.DropTableAsync<Term>();
            await dbs.DropTableAsync<Course>();
            await dbs.DropTableAsync<Assessment>();
            dbs = null;



        }
        #endregion
    }

}
