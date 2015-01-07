using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace ExportQrCode
{
    [Cmdlet(VerbsData.Export, "QrCode")]
    public class ExportQrCode : PSCmdlet, IDynamicParameters
    {
        private const string DarkBrush = "DarkBrush";
        private const string LightBrush = "LightBrush";

        private static RuntimeDefinedParameterDictionary staticStorage;

        private string errorCorrectionLevel = "M";
        private int moduleSize = 2;
       
        #region Text

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "Text that will be inculude in QrCode"
            )]
        [ValidateNotNullOrEmpty]
        public string Text { get; set; }
            #endregion
        
        #region OutputPath

        [Parameter(
            Mandatory = false,
            Position = 1,
            HelpMessage = "OutputPath for QRCode file, if not present it will be stored under MyPictures"
            )]
        public string OutputPath { get; set; }
        #endregion

        #region OpenWithShellExtension
        [Parameter(
            Mandatory = false,
            HelpMessage = "OpenWithShellExtension"
            )]
        public SwitchParameter OpenWithShellExtension { get; set; }

        #endregion

        #region ErrorCorrectionLevel
        [Parameter(
            Mandatory = false,
            HelpMessage = "ErrorCorrectionLevel"
            )]
        [ValidateSet(new[] {"L", "M", "Q", "H"}, IgnoreCase = true)]
        public string ErrorCorrectionLevel
        {
            get { return this.errorCorrectionLevel; }
            set { this.errorCorrectionLevel = value; }
        }

        #endregion

        #region ModuleSize
        [Parameter(
            Mandatory = false,
            HelpMessage = "ModuleSize"
            )]
        [ValidateRange(2, 64)]
        public int ModuleSize
        {
            get { return this.moduleSize; }
            set { this.moduleSize = value; }
        }

        #endregion

        public object GetDynamicParameters()
        {
            IEnumerable<string> brushes = typeof (Brushes).GetProperties().Select(x => x.Name);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            var attributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    HelpMessage = "Brush"
                },
                new ValidateSetAttribute(brushes.ToArray()),
            };

            runtimeDefinedParameterDictionary.Add(DarkBrush, new RuntimeDefinedParameter(DarkBrush, typeof (string), attributes));
            runtimeDefinedParameterDictionary.Add(LightBrush, new RuntimeDefinedParameter(LightBrush, typeof (string), attributes));
            staticStorage = runtimeDefinedParameterDictionary;

            return runtimeDefinedParameterDictionary;
        }
    
        protected override void BeginProcessing()
        {
            if (String.IsNullOrWhiteSpace(this.OutputPath))
            {
                string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "QrCodes", Guid.NewGuid() + ".png");
                Directory.CreateDirectory(new FileInfo(outputPath).DirectoryName);
                this.OutputPath = outputPath;
            }

            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            ErrorCorrectionLevel errorCorrectionLevel;
            Enum.TryParse(this.ErrorCorrectionLevel, true, out errorCorrectionLevel);
            var encoder = new QrEncoder(errorCorrectionLevel);

            QrCode qrCode;
            encoder.TryEncode(this.Text, out qrCode);

            var gRenderer = new GraphicsRenderer(new FixedModuleSize(this.ModuleSize, QuietZoneModules.Two), this.GetBrush(DarkBrush), this.GetBrush(LightBrush));

            var ms = new MemoryStream();
            gRenderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            byte[] data = ms.ToArray();

            File.WriteAllBytes(this.OutputPath, data);

            if (this.OpenWithShellExtension.ToBool())
            {
                Process.Start(this.OutputPath);
            }

            this.WriteObject(this.OutputPath);
        }

        private Brush GetBrush(string runtimeDefinedParameter)
        {
            KeyValuePair<string, RuntimeDefinedParameter> runtimeDefinedParameterTables = staticStorage.FirstOrDefault(x => x.Key == runtimeDefinedParameter);
            if (runtimeDefinedParameterTables.Value == null) return runtimeDefinedParameter == LightBrush ? Brushes.White : Brushes.Black;

            var brushName = (string) (runtimeDefinedParameterTables.Value.Value);
            if (brushName == null) return runtimeDefinedParameter == LightBrush ? Brushes.White : Brushes.Black;

            PropertyInfo propertyInfo = typeof (Brushes).GetProperties().FirstOrDefault(x => x.Name == brushName);
            if (propertyInfo == null) return runtimeDefinedParameter == LightBrush ? Brushes.White : Brushes.Black;

            var brush = propertyInfo.GetValue(null, null) as Brush;
            if (brush == null) return runtimeDefinedParameter == LightBrush ? Brushes.White : Brushes.Black;

            return brush;
        }
    }
}