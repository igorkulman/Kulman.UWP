using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using JetBrains.Annotations;
using Kulman.UWP.Code;
using Kulman.UWP.Interfaces;

namespace Kulman.UWP.Services
{
    /// <summary>
    /// Helper class for showing message dialogs
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>
        /// Shows a dialog with given message and ok/cancel buttons. 
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        /// <param name="leftButtonText">Left button text (optional)</param>
        /// <param name="rightButtonText">Right button text (optional)</param>
        /// <returns>Dialog result</returns>
        public async Task<DialogResult> ShowMessageDialog([NotNull] string message, [CanBeNull] string title = null, [CanBeNull] string leftButtonText = null, [CanBeNull] string rightButtonText = null)
        {
            var result = DialogResult.NothingPressed;
            var dialog = string.IsNullOrEmpty(title) ? new MessageDialog(message) :new MessageDialog(message, title);

            if (!string.IsNullOrWhiteSpace(leftButtonText))
            {
                dialog.Commands.Add(new UICommand(leftButtonText, cmd => result = DialogResult.LeftButtonPressed));
            }

            if (!string.IsNullOrWhiteSpace(rightButtonText))
            {
                dialog.Commands.Add(new UICommand(rightButtonText, cmd => result = DialogResult.RightButtonPressed));
            }

            await dialog.ShowAsync();
            return result;
        }
    }
}