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
        public bool CollegePackedCompleted { get; set; }
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
        
   


    }
}
