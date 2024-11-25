// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.FileUpload
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class FileUpload : ComponentBase
    {
        private bool dialogInvoked;
        private string script = "function allowDrapDrop (id) { let element = document.querySelector(id);element?.addEventListener('drop', e => {e.preventDefault();const inputFile = document.querySelector(id + ' input[type=file]');inputFile.files = e.dataTransfer.files;const event = new Event('change', { bubbles: true });inputFile.dispatchEvent(event);});}function invokeClick (id, e = null) {let element = document.querySelector(id + ' input[type=file]');if (e) { element.files = e.dataTransfer.files; const event = new Event('drop', { bubbles: true }); element.dispatchEvent(event);} else element?.click(); }";
        private Dictionary<string, string>? errors = new Dictionary<string, string>();
        private List<string> images = new List<string>();

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            if (!this.Visible)
                return;
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", this.Id);
            __builder.AddAttribute(2, "class", (this.Disabled ? "sbc-fileupload disabled" : "sbc-fileupload") + " " + this.Class);
            __builder.AddAttribute(3, "style", this.Style);
            __builder.AddAttribute(4, "ondragover", "event.preventDefault()");
            __builder.AddAttribute(5, "ondrop", "event.preventDefault()");
            __builder.AddAttribute(6, "b-emlxcnw45e");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "sbc-fileupload-container");
            __builder.AddAttribute<MouseEventArgs>(9, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object)this, new Func<Task>(this.InvokeFileBrowser)));
            __builder.AddAttribute(10, "b-emlxcnw45e");
            __builder.OpenComponent<Sysinfocus.AspNetCore.Components.Icon>(11);
            __builder.AddComponentParameter(12, "Class", (object)"sbc-fileupload-icon");
            __builder.AddComponentParameter(13, "Name", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.Icon));
            __builder.AddComponentParameter(14, "Size", (object)"48px");
            __builder.CloseComponent();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "small");
            __builder.AddAttribute(17, "style", "margin-top: 8px");
            __builder.AddAttribute(18, "b-emlxcnw45e");
            __builder.AddContent(19, (MarkupString)this.Text);
            __builder.CloseElement();
            if (!InitializeSysinfocus.IsLicensed)
                __builder.AddMarkupContent(20, "<small class=\"mtb1\" b-emlxcnw45e>You are using a trial version.</small>");
            if (this.AllowedFileCount > 1)
            {
                __builder.OpenComponent<InputFile>(21);
                __builder.AddComponentParameter(22, "accesskey", (object)this.AccessKey);
                __builder.AddComponentParameter(23, "OnChange", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<InputFileChangeEventArgs>>(EventCallback.Factory.Create<InputFileChangeEventArgs>((object)this, new Func<InputFileChangeEventArgs, Task>(this.HandleFileSelection))));
                __builder.AddComponentParameter(24, "multiple", (object)true);
                __builder.CloseComponent();
            }
            else
            {
                __builder.OpenComponent<InputFile>(25);
                __builder.AddComponentParameter(26, "accesskey", (object)this.AccessKey);
                __builder.AddComponentParameter(27, "OnChange", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<InputFileChangeEventArgs>>(EventCallback.Factory.Create<InputFileChangeEventArgs>((object)this, new Func<InputFileChangeEventArgs, Task>(this.HandleFileSelection))));
                __builder.CloseComponent();
            }
            __builder.CloseElement();
            if (!string.IsNullOrEmpty(this.InitialImage))
            {
                __builder.OpenElement(28, "img");
                __builder.AddAttribute(29, "src", this.InitialImage);
                __builder.AddAttribute(30, "b-emlxcnw45e");
                __builder.CloseElement();
            }
            __builder.CloseElement();
        }

        [Parameter]
        public
#nullable enable
        string? AccessKey
        { get; set; }

        [Parameter]
        public string? Id { get; set; } = "fu-" + Guid.NewGuid().ToString();

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter]
        public string[]? AllowedFileTypes { get; set; } = new string[4]
        {
      ".png",
      ".jpg",
      ".jpeg",
      ".gif"
        };

        [Parameter]
        public int AllowedFileCount { get; set; } = 1;

        [Parameter]
        public long MaxFileSizeInKB { get; set; } = 1024;

        [Parameter]
        public bool Visible { get; set; } = true;

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? Icon { get; set; } = "upload_file";

        [Parameter]
        public string Text { get; set; } = "Drag and drop files or Click here to upload";

        [Parameter]
        public string? ImageFormat { get; set; } = "image/png";

        [Parameter]
        public string? InitialImage { get; set; }

        [Parameter]
        public bool IgnoreErrors { get; set; }

        [Parameter]
        public bool IsImage { get; set; }

        [Parameter]
        public EventCallback<Dictionary<string, string>?> OnError { get; set; }

        [Parameter]
        public EventCallback<IReadOnlyList<IBrowserFile>> OnUpload { get; set; }

        [Parameter]
        public EventCallback<ICollection<string>> OnImagesUpload { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;
            await this.be.EvalVoid((object)this.script);
            await this.be.JSVoid("allowDrapDrop", (object)("#" + this.Id));
        }

        private async Task InvokeFileBrowser()
        {
            if (this.dialogInvoked)
                return;
            this.errors?.Clear();
            this.dialogInvoked = true;
            await this.be.JSVoid("invokeClick", (object)("#" + this.Id), null);
            this.dialogInvoked = false;
        }

        private async Task HandleFileSelection(InputFileChangeEventArgs args)
        {
            this.errors?.Clear();
            List<IBrowserFile> files = this.ValidFiles(args.GetMultipleFiles(args.FileCount)).ToList<IBrowserFile>();
            Dictionary<string, string> errors = this.errors;
            if (errors != null && errors.Count > 0)
            {
                await this.OnError.InvokeAsync(this.errors);

                if (!this.IgnoreErrors)
                {
                    files = null;
                    return;
                }
            }

            await this.OnUpload.InvokeAsync((IReadOnlyList<IBrowserFile>)files.Take<IBrowserFile>(this.AllowedFileCount).ToList<IBrowserFile>());
            if (!this.IsImage)
            {
                files = (List<IBrowserFile>)null;
            }
            else
            {
                await this.ConverToImages((IReadOnlyList<IBrowserFile>)files.Take<IBrowserFile>(this.AllowedFileCount).ToList<IBrowserFile>());
                await this.OnImagesUpload.InvokeAsync((ICollection<string>)this.images);
                files = (List<IBrowserFile>)null;
            }
        }

        private bool ValidFile(IBrowserFile file)
        {
            if (file.Size > 1024L * this.MaxFileSizeInKB)
            {
                Dictionary<string, string> errors = this.errors;
                if (errors != null)
                {
                    string name = file.Name;
                    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
                    interpolatedStringHandler.AppendLiteral("File size more than ");
                    interpolatedStringHandler.AppendFormatted<long>(this.MaxFileSizeInKB);
                    interpolatedStringHandler.AppendLiteral(" KB");
                    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                    // ISSUE: explicit non-virtual call
                    errors.Add(name, stringAndClear);
                }
                return false;
            }
            string[] allowedFileTypes1 = this.AllowedFileTypes;
            if (allowedFileTypes1 != null && ((IEnumerable<string>)allowedFileTypes1).Contains<string>("*"))
                return true;
            string lower = Path.GetExtension(file.Name).ToLower();
            string[] allowedFileTypes2 = this.AllowedFileTypes;
            if (allowedFileTypes2 == null || ((IEnumerable<string>)allowedFileTypes2).Contains<string>(lower))
                return true;
            this.errors?.Add(file.Name, "Invalid file extensions.");
            return false;
        }

        private IReadOnlyList<IBrowserFile> ValidFiles(IReadOnlyList<IBrowserFile> files)
        {
            List<IBrowserFile> browserFileList = new List<IBrowserFile>();
            foreach (IBrowserFile file in (IEnumerable<IBrowserFile>)files)
            {
                if (this.ValidFile(file))
                    browserFileList.Add(file);
            }
            return (IReadOnlyList<IBrowserFile>)browserFileList;
        }

        private async Task ConverToImages(IReadOnlyList<IBrowserFile> files)
        {
            this.images = new List<string>();
            foreach (IBrowserFile file in (IEnumerable<IBrowserFile>)files)
            {
                if (file.ContentType.ToLower().StartsWith("img") || file.ContentType.ToLower().StartsWith("image"))
                {
                    List<string> stringList = this.images;
                    string str = await this.GetImageData(file);
                    stringList.Add(str);
                    stringList = (List<string>)null;
                    str = (string)null;
                }
            }
        }

        private async Task<string> GetImageData(IBrowserFile file)
        {
            byte[] buf = new byte[file.Size];
            Stream fs = file.OpenReadStream(file.Size * this.MaxFileSizeInKB);
            string imageData;
            try
            {
                int num = await fs.ReadAsync((Memory<byte>)buf);
                imageData = !(Path.GetExtension(file.Name).ToLower() == ".svg") ? "data:" + this.ImageFormat + ";base64," + Convert.ToBase64String(buf) : "data:image/svg+xml;base64," + Convert.ToBase64String(buf);
            }
            finally
            {
                fs?.Dispose();
            }
            buf = (byte[])null;
            fs = (Stream)null;
            return imageData;
        }

        [Inject]
        private BrowserExtensions be { get; set; } = (BrowserExtensions)null;

        [Inject]
        private StateManager sm { get; set; } = (StateManager)null;
    }
}
