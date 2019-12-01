using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenttracking.Models
{
    public class Student
    {
        public string StudentName { get; set; }
        public string CoachName { get; set; }
        public bool FirstGeneration { get; set; }
        public string Race { get; set; }
        public bool Disability { get; set; }
        public Classification Classification { get; set; }
        public bool SevenTargetedSchoolCompleted { get; set; }
        public bool NotifiedStudent { get; set; }
        public bool ScholarshipMatchingComplete { get; set; }
        public bool ScholarshipEssay { get; set; }
        public DateTime ScholarshipDeadline { get; set; }
        public DateTime ScholarshipEssayThree { get; set; }
        public string ReviewOfEssay { get; set; }
        public string CollegeApplicationDeadline { get; set; }
        public bool CompletedFAFSA { get; set; }
        public string AdmissionDeadline { get; set; }
        public bool Rejected { get; set; }
        public bool Waitlisted { get; set; }
        public bool Accepted { get; set; }
        public bool CollegePacketCompleted { get; set; }
        public string CoachFinalReview { get; set; }
        public string LOR { get; set; }
        public bool Resume { get; set; }
        public bool Interview { get; set; }
        public double ScholarshipAwarded { get; set; }

        public Student(string coachName, string race, Classification classification, DateTime scholarshipDeadline,
             DateTime scholarshipEssayThree, string reviewOfEssay, string collegeApplicationDeadline, string addmissionDeadline,
             string coachFinalReview, string lor, double scholarshipAwarded)
        {
            this.CoachName = !string.IsNullOrEmpty(coachName) ? coachName : throw new ArgumentNullException(nameof(coachName));
            this.Race = !string.IsNullOrEmpty(race) ? race : throw new ArgumentNullException(nameof(race));
            this.Classification = classification;
            this.ScholarshipDeadline = scholarshipDeadline != null ? scholarshipDeadline : throw new ArgumentNullException(nameof(scholarshipDeadline));
            this.ScholarshipEssayThree = scholarshipEssayThree != null ? scholarshipEssayThree : throw new ArgumentNullException(nameof(scholarshipEssayThree));
            this.ReviewOfEssay = !string.IsNullOrEmpty(reviewOfEssay) ? reviewOfEssay : throw new ArgumentNullException(nameof(reviewOfEssay));
            this.CollegeApplicationDeadline = !string.IsNullOrEmpty(collegeApplicationDeadline) ? collegeApplicationDeadline : throw new ArgumentNullException(collegeApplicationDeadline);
            this.AdmissionDeadline = !string.IsNullOrEmpty(addmissionDeadline) ? addmissionDeadline : throw new ArgumentNullException(nameof(addmissionDeadline));
            this.CoachFinalReview = !string.IsNullOrEmpty(coachFinalReview) ? coachFinalReview : throw new ArgumentNullException(nameof(coachFinalReview));
            this.ScholarshipAwarded = scholarshipAwarded > 0 ? scholarshipAwarded : throw new ArgumentOutOfRangeException(nameof(scholarshipAwarded));
        }

        public Student(string studentName)
        {
            this.StudentName = studentName;
        }

        public static class Fields
        {
            public const string StudentName                     = "Student's Name";
            public const string CoachName                       = "Coach Name";
            public const string FirstGeneration                 = "1st Generation?";
            public const string Race                            = "Race";
            public const string Disability                      = "Disability?";
            public const string Classification                  = "Classification";
            public const string SevenTargetedSchoolCompleted    = "7 Target Schools Completed?";
            public const string NotifiedStudent                 = "Notified Student?";
            public const string ScholarshipMatchingComplete     = "Scholarship Matching Complete?";
            public const string ScholarshipEssay                = "Scholarship Essay";
            public const string ScholarshipDeadline             = "Scholarship Deadlines";
            public const string ScholarshipEssayThree           = "Scholarship Essay #3";
            public const string ReviewOfEssay                   = "Review of Essay?";
            public const string CollegeApplicationDeadline      = "College Application Deadlines?";
            public const string CompletedFAFSA                  = "Completed FAFSA?";
            public const string AdmissionDeadline               = "Admission Deadlines";
            public const string Rejected                        = "Rejected?";
            public const string Waitlisted                      = "Waitlisted?";
            public const string Accepted                        = "Accepted ?";
            public const string CollegePacketCompleted          = "College Packet Complete?";
            public const string CoachFinalReview                = "Coach Final Review";
            public const string LOR                             = "LOR";
            public const string Resume                          = "Resume";
            public const string Interview                       = "Interview?";
            public const string ScholarshipAwarded              = "Scholarship Awarded";

            private static string[] Values = 
            {
                StudentName,
                CoachName,
                FirstGeneration,
                Race,
                Disability,
                Classification,
                SevenTargetedSchoolCompleted,
                NotifiedStudent,
                ScholarshipMatchingComplete,
                ScholarshipEssay,
                ScholarshipDeadline,
                ScholarshipEssayThree,
                ReviewOfEssay,
                CollegeApplicationDeadline,
                CompletedFAFSA,
                AdmissionDeadline,
                Rejected,
                Waitlisted,
                Accepted,
                CollegePacketCompleted,
                CoachFinalReview,
                LOR,
                Resume,
                Interview,
                ScholarshipAwarded
            };


            public static IDictionary<string, int> GetHeaders(string headerLine)
            {
                var headersMap = new Dictionary<string, int>();
                var headers = headerLine.Split(',');
                headersMap.Add(Headers.StudentName, Array.IndexOf(headers, StudentName));
                headersMap.Add(Headers.CoachName, Array.IndexOf(headers, CoachName));
                headersMap.Add(Headers.FirstGeneration, Array.IndexOf(headers, FirstGeneration));
                headersMap.Add(Headers.Race, Array.IndexOf(headers, Race));
                headersMap.Add(Headers.Disability, Array.IndexOf(headers, Disability));
                headersMap.Add(Headers.Classification, Array.IndexOf(headers, Classification));
                headersMap.Add(Headers.SevenTargetedSchoolCompleted, Array.IndexOf(headers, SevenTargetedSchoolCompleted));
                headersMap.Add(Headers.ScholarshipMatchingComplete, Array.IndexOf(headers, ScholarshipMatchingComplete));
                headersMap.Add(Headers.ScholarshipEssay, Array.IndexOf(headers, ScholarshipEssay));
                headersMap.Add(Headers.ScholarshipDeadline, Array.IndexOf(headers, ScholarshipDeadline));
                headersMap.Add(Headers.ScholarshipEssayThree, Array.IndexOf(headers, ScholarshipEssayThree));
                headersMap.Add(Headers.ReviewOfEssay, Array.IndexOf(headers, ReviewOfEssay));
                headersMap.Add(Headers.CollegeApplicationDeadline, Array.IndexOf(headers, CollegeApplicationDeadline));
                headersMap.Add(Headers.CompletedFAFSA, Array.IndexOf(headers, CompletedFAFSA));
                headersMap.Add(Headers.AdmissionDeadline, Array.IndexOf(headers, AdmissionDeadline));
                headersMap.Add(Headers.Rejected, Array.IndexOf(headers, Rejected));
                headersMap.Add(Headers.Waitlisted, Array.IndexOf(headers, Waitlisted));
                headersMap.Add(Headers.Accepted, Array.IndexOf(headers, Accepted));
                headersMap.Add(Headers.CollegePacketCompleted, Array.IndexOf(headers, CollegePacketCompleted));
                headersMap.Add(Headers.CoachFinalReview, Array.IndexOf(headers, CoachFinalReview));
                headersMap.Add(Headers.LOR, Array.IndexOf(headers, LOR));
                headersMap.Add(Headers.Resume, Array.IndexOf(headers, Resume));
                headersMap.Add(Headers.Interview, Array.IndexOf(headers, Interview));
                headersMap.Add(Headers.ScholarshipAwarded, Array.IndexOf(headers, ScholarshipAwarded));
                return headersMap;
            }

            public static class Headers
            {
                public const string StudentName                         = "StudentName";
                public const string CoachName                           = "CoachName";
                public const string FirstGeneration                     = "FirstGeneration";
                public const string Race                                = "Race";
                public const string Disability                          = "Disability";
                public const string Classification                      = "Classification";
                public const string SevenTargetedSchoolCompleted        = "SevenTargetedSchoolCompleted";
                public const string NotifiedStudent                     = "NotifiedStudent";
                public const string ScholarshipMatchingComplete         = "ScholarshipMatchingComplete";
                public const string ScholarshipEssay                    = "ScholarshipEssay";
                public const string ScholarshipDeadline                 = "ScholarshipDeadline";
                public const string ScholarshipEssayThree               = "ScholarshipEssayThree";
                public const string ReviewOfEssay                       = "ReviewOfEssay";
                public const string CollegeApplicationDeadline          = "CollegeApplicationDeadline";
                public const string CompletedFAFSA                      = "CompletedFAFSA";
                public const string AdmissionDeadline                   = "AdmissionDeadline";
                public const string Rejected                            = "Rejected";
                public const string Waitlisted                          = "Waitlisted";
                public const string Accepted                            = "Accepted";
                public const string CollegePacketCompleted              = "CollegePacketCompleted";
                public const string CoachFinalReview                    = "CoachFinalReview";
                public const string LOR                                 = "LOR";
                public const string Resume                              = "Resume";
                public const string Interview                           = "Interview";
                public const string ScholarshipAwarded                  = "ScholarshipAwarded";
            }

        }
        
   


    }
}
