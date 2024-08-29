#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


namespace Goedel.Mesh.Shell;

public partial class Shell {

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult LogCreate(LogCreate options) {
        var outputFile = options.Sequence.Value;

        var keyLocate = GetKeyCollection(options);
        var policy = GetPolicy(keyLocate, options);


        using (var log = new DareLogWriter(
                outputFile, policy: policy, fileStatus: FileStatus.Overwrite)) {
            }

        return new ResultFile() {
            Filename = outputFile
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult LogAppend(LogAppend options) {

        var outputFile = options.Sequence.Value;
        var Entry = options.Entry.Value;

        using var writer = new DareLogWriter(
                outputFile, null, fileStatus: FileStatus.Existing);


        var data = Entry.ToUTF8();
        var contentMeta = new ContentMeta() {
            Created = System.DateTime.Now
            };

        writer.AddData(data, contentMeta);

        return new ResultLog() {
            Count = (int)writer.Sequence.FrameCount
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult LogList(LogList options) {
        var inputFile = options.Sequence.Value;
        var outputFile = options.Output.Value;
        var contextAccount = GetContextUser(options);

        using var reader = new DareLogReader(inputFile, contextAccount);
        using var output = outputFile.OpenTextWriterNew();

        var count = reader.List(output);

        var result = new ResultListLog() {
            Filename = outputFile,
            Count = count
            };

        return result;
        }




    }
