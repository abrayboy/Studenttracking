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
            var headerFields = headers.Split(',');
            var headerMap = Student.Fields.GetHeaders(headers);
            for (var i = 1; i < lines.Count; i++)
            {
                try
                {
                    var fields = lines[i].Split(',');
                    var student = new Student(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.CoachName)).Value], fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Race)).Value],
                        ClassificationUtils.GetClassification(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Classification)).Value]), DateTime.Parse(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.ScholarshipDeadline)).Value]),
                        DateTime.Parse(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.ScholarshipEssayThree)).Value]), fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.ReviewOfEssay)).Value],
                        fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.CollegeApplicationDeadline)).Value], fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.AdmissionDeadline)).Value],
                        fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.CoachFinalReview)).Value], fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.LOR)).Value],
                        double.Parse(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.ScholarshipEssayThree)).Value]))
                    {
                        FirstGeneration = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.FirstGeneration)).Value]),
                        Disability = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Disability)).Value]),
                        SevenTargetedSchoolCompleted = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.SevenTargetedSchoolCompleted)).Value]),
                        NotifiedStudent = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.NotifiedStudent)).Value]),
                        ScholarshipMatchingComplete = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.ScholarshipMatchingComplete)).Value]),
                        ScholarshipEssay = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.ScholarshipEssay)).Value]),
                        CompletedFAFSA = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.CompletedFAFSA)).Value]),
                        Rejected = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Rejected)).Value]),
                        Waitlisted = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Waitlisted)).Value]),
                        Accepted = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Accepted)).Value]),
                        CollegePacketCompleted = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.CollegePacketCompleted)).Value]),
                        Resume = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Resume)).Value]),
                        Interview = TextToBool.Get(fields[headerMap.First(k => k.Key.Equals(Student.Fields.Headers.Interview)).Value])
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

        private IDictionary<string, int> GetIndexes(string[] headers)
        {
            var indexMap = new Dictionary<string, int>();
            return indexMap;
        }
    }
}
