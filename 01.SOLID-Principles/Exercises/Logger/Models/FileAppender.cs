namespace LoggerExerciese.Models.Factories
{
    internal class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
            this.AppendedMessages = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public int AppendedMessages { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);

            this.logFile.WriteToFile(formattedError);

            this.AppendedMessages++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string errorLevel = this.ErrorLevel.ToString();

            return $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages appended: {this.AppendedMessages} File size: {this.logFile.Size}";
        }
    }
}