using System.Threading.Tasks;
using JetBrains.Annotations;
using Kulman.UWP.Code;

namespace Kulman.UWP.Interfaces
{
    public interface IDialogService
    {
        /// <summary>
        /// Shows a dialog with given message and ok/cancel buttons. 
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        /// <param name="leftButtonText">Left button text (optional)</param>
        /// <param name="rightButtonText">Right button text (optional)</param>
        /// <returns>Dialog result</returns>
        Task<DialogResult> ShowMessageDialog([NotNull] string message, [CanBeNull] string title = null, [CanBeNull] string leftButtonText = null, [CanBeNull] string rightButtonText = null);
    }
}