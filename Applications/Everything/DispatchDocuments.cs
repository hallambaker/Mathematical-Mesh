﻿namespace Goedel.Everything;
public partial class EverythingMaui {

    // *********************** NYI


    ///<inheritdoc/>
    public override async Task<IResult> SendDocument(SendDocument data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    ///<inheritdoc/>
    public override async Task<IResult> ShareDocument(ShareDocument data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    }
