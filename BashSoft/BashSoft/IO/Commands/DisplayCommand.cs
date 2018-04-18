using BashSoft;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using System;
using System.Collections.Generic;

[Alias("display")]
public class DisplayCommand : Command
{
    [Inject]
    private IDatabase repo;

    private string input;
    private string[] data;

    public DisplayCommand(string input, string[] data)
        : base(input, data)
    {
    }

    public string Input { get => input; set => input = value; }
    public string[] Data { get => data; set => data = value; }


    public override void Execute()
    {
        if (this.Data.Length != 3)
        {
            throw new InvalidCommandException(this.Input);
        }

        string entityToDisplay = this.Data[1];
        string sortType = this.Data[2];

        if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
        {
            IComparer<IStudent> studentComparator = this.CreateStudentComparator(sortType);
            ISimpleOrderedBag<IStudent> list = this.repo.GetAllStudentsSorted(studentComparator);

            OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
        }
        else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
        {
            IComparer<ICourse> courseComparator = this.CreateCourseComparator(sortType);
            ISimpleOrderedBag<ICourse> list = this.repo.GetAllCoursesSorted(courseComparator);

            OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
        }
    }

    private IComparer<IStudent> CreateStudentComparator(string sortType)
    {
        if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
        {
            return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
        }

        if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
        {
            return Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
        }

        throw new InvalidCommandException(this.Input);
    }

    private IComparer<ICourse> CreateCourseComparator(string sortType)
    {
        if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
        {
            return Comparer<ICourse>.Create((courseOne, courseTwo) => courseOne.CompareTo(courseTwo));
        }

        if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
        {
            return Comparer<ICourse>.Create((courseOne, courseTwo) => courseTwo.CompareTo(courseOne));
        }

        throw new InvalidCommandException(this.Input);
    }

}
