namespace LogLibrary
{
    /// <summary>
    /// Logger interface for recording moves
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Method for recording moves
        /// </summary>
        /// <param name="message"></param>
        void Write(string message);
    }
}
