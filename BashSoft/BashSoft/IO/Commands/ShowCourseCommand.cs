namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;

    [Alias("show")]
    public class ShowCourseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repo;

        public ShowCourseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.repo.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.repo.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
