using Studenttracking.Models;
using Studenttracking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Studenttracking.IO
{
    public class StudentManagerBuilder
    {
        private IList<string> errors;

        public IList<string> Errors => errors;

        public StudentManagerBuilder()
        {
            this.errors = new List<string>();
        }

        public async Task<StudentManager> Build(StorageFile spreadSheet)
        {
            var lines = await FileIO.ReadLinesAsync(spreadSheet);
            var studentManager = new StudentManager();
            var headers = lines[0];
            for (var i = 1; i < lines.Count; i++)
            {
                try
                {
                    var fields = lines[i].Split(',');
                    var student = new Student(fields[Array.IndexOf(fields, Student.Fields.CoachName)], fields[Array.IndexOf(fields, Student.Fields.Race)],
                        GetClassification(fields[Array.IndexOf(fields, Student.Fields.Classification)]), DateTime.Parse(fields[Array.IndexOf(fields, Student.Fields.ScholarshipDeadline)]),
                        DateTime.Parse(fields[Array.IndexOf(fields, Student.Fields.ScholarshipEssayThree)]), fields[Array.IndexOf(fields, Student.Fields.ReviewOfEssay)],
                        fields[Array.IndexOf(fields, Student.Fields.CollegeApplicationDeadline)], fields[Array.IndexOf(fields, Student.Fields.AdmissionDeadline)],
                        fields[Array.IndexOf(fields, Student.Fields.CoachFinalReview)], fields[Array.IndexOf(fields, Student.Fields.LOR)],
                        double.Parse(fields[Array.IndexOf(fields, Student.Fields.ScholarshipEssayThree)]))
                    {
                        FirstGeneration = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.FirstGeneration)]),
                        Disability = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.Disability)]),
                        SevenTargetedSchoolCompleted = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.SevenTargetedSchoolCompleted)]),
                        NotifiedStudent = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.NotifiedStudent)]),
                        ScholarshipMatchingComplete = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.ScholarshipMatchingComplete)]),
                        ScholarshipEssay = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.ScholarshipEssay)]),
                        CompletedFAFSA = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.CompletedFAFSA)]),
                        Rejected = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.Rejected)]),
                        Waitlisted = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.Waitlisted)]),
                        Accepted = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.Accepted)]),
                        CollegePacketCompleted = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.CollegePacketCompleted)]),
                        Resume = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.Resume)]),
                        Interview = TextToBool.Get(fields[Array.IndexOf(fields, Student.Fields.Interview)])
                    };
                    studentManager.Add(student);
                }
                catch (Exception e)
                {
                    this.errors.Add(getErrorMessage(i, spreadSheet.DisplayName, e));
                    continue;
                }
            }
            return studentManager;
        }

        private string getErrorMessage(int lineNumber, string fileName, Exception e)
        {
            return $"Error reading line {lineNumber} of input file {fileName}: {e.Message}";
        }

        private Classification GetClassification(string classification)
        {
            switch(classification.Trim().ToLower())
            {
                case "senior":
                    return Classification.Senior;
                case "junior":
                    return Classification.Junior;
                case "sophomore":
                    return Classification.Sophomore;
                case "freshman":
                    return Classification.Freshman;
                case "grad":
                    return Classification.Grad;
                case "grad/med":
                    return Classification.Grad_Med;
                case "law":
                    return Classification.Law;
                case "engineering":
                    return Classification.Engineering;
                case "med":
                    return Classification.Med;
                case "phd":
                    return Classification.Phd;
                default:
                    return Classification.None;
            }
        }
    }
}
