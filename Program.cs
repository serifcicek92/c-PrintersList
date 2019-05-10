using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace printers
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllPrinterList();
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //https://docs.microsoft.com/en-us/windows/desktop/cimwin32prov/win32-printer
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        static List<PrintersInfo> GetPrintersInfos()
        {
            List<PrintersInfo> devices = new List<PrintersInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From win32_Printer"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new PrintersInfo(
                (string)device.GetPropertyValue("Name"),
                (string)device.GetPropertyValue("PortName"),
                (string)device.GetPropertyValue("Description"),
                (string)device.GetPropertyValue("Status"),
                //(string)device.GetPropertyValue("StatusInfo"),
                (string)device.GetPropertyValue("SystemCreationClassName"),
              //  (string)device.GetPropertyValue("PrinterState"),
                //(string)device.GetPropertyValue("PrinterStatus"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("Parameters"),
                (string)device.GetPropertyValue("Location"),
                (string)device.GetPropertyValue("ErrorDescription"),
                //(string)device.GetPropertyValue("LastErrorCode"),
                //(string)device.GetPropertyValue("ExtendedPrinterStatus"),
               // (string)device.GetPropertyValue("ExtendedDetectedErrorState"),
                (string)device.GetPropertyValue("DriverName"),
                (string)device.GetPropertyValue("DefaultPaperType"),
                //(int)device.GetPropertyValue("DefaultCopies"),
                (string)device.GetPropertyValue("CurrentPaperType"),
                (string)device.GetPropertyValue("Comment"),
                (string)device.GetPropertyValue("Caption")

                ));
            }

            collection.Dispose();
            return devices;
        }

        class PrintersInfo
        {
            public PrintersInfo(
                  string Name
                , string PortName
                , string Description
                , string Status
                //, string StatusInfo
                , string SystemCreationClassName
               // , string PrinterState
                //, string PrinterStatus
                , string PNPDeviceID
                , string DeviceID
                , string Parameters
                , string Location
                , string ErrorDescription
                //, string LastErrorCode
                //, string ExtendedPrinterStatus
                //, string ExtendedDetectedErrorState
                , string DriverName
                , string DefaultPaperType
                //, int DefaultCopies
                , string CurrentPaperType
                , string Comment
                , string Caption
                )
            {
                
                this.Name = Name;
                this.PortName = PortName;
                this.Description = Description;
                this.Status = Status;
                this.StatusInfo = StatusInfo;
                this.SystemCreationClassName = SystemCreationClassName;
                this.PrinterState = PrinterState;
                this.PrinterStatus = PrinterStatus;
                this.PNPDeviceID = PNPDeviceID;
                this.DeviceID = DeviceID;
                this.Parameters = Parameters;
                this.Location = Location;
                this.ErrorDescription = ErrorDescription;
                this.LastErrorCode = LastErrorCode;
                this.ExtendedPrinterStatus = ExtendedPrinterStatus;
                this.ExtendedDetectedErrorState = ExtendedDetectedErrorState;
                this.DriverName = DriverName;
                this.DefaultPaperType = DefaultPaperType;
                this.DefaultCopies = DefaultCopies;
                this.CurrentPaperType = CurrentPaperType;
                this.Comment = Comment;
                this.Caption = Caption;
            }
            public string Name { get; private set; }
            public string PortName { get; private set; }
            public string Description { get; private set; }
            public string Status { get; private set; }
            public string StatusInfo { get; private set; }
            public string SystemCreationClassName { get; private set; }
            public string PrinterState { get; private set; }
            public string PrinterStatus { get; private set; }
            public string PNPDeviceID { get; private set; }
            public string Parameters { get; private set; }
            public string Location { get; private set; }
            public string LastErrorCode { get; private set; }
            public string ExtendedPrinterStatus { get; private set; }
            public string ExtendedDetectedErrorState { get; private set; }
            public string DriverName { get; private set; }
            public string DefaultPaperType { get; private set; }
            public int DefaultCopies { get; private set; }
            public string CurrentPaperType { get; private set; }
            public string Comment { get; private set; }
            public string Caption { get; private set; }
            public string DeviceID { get; private set; }
            public string ErrorDescription { get; set; }
        }

        public static void GetAllPrinterList()
        {
            var printers = GetPrintersInfos();

            foreach (var printer in printers)
            {
                Console.WriteLine(
                        "İsim: " + printer.Name
                        + "\n Port Adı: " + printer.PortName
                        + "\n Durumu: " + printer.Status
                        + "\n StatusInfo: " + printer.StatusInfo
                        + "\n SystemCreationClassName: " + printer.SystemCreationClassName
                        + "\n PrinterState: " + printer.PrinterState
                        + "\n PrinterStatus: " + printer.PrinterStatus
                        + "\n PNPDeviceID: " + printer.PNPDeviceID
                        + "\n DeviceID: " + printer.PNPDeviceID
                        + "\n Parameters: " + printer.Parameters
                        + "\n Location: " + printer.Location
                        + "\n LastErrorCode: " + printer.LastErrorCode
                        + "\n ExtendedPrinterStatus: " + printer.ExtendedPrinterStatus
                        + "\n ExtendedDetectedErrorState: " + printer.ExtendedDetectedErrorState
                        + "\n ErrorDescription: " + printer.Description
                        + "\n DriverName: " + printer.DriverName
                        + "\n DefaultPaperType: " + printer.DefaultPaperType
                        + "\n DefaultCopies: " + printer.DefaultCopies
                        + "\n CurrentPaperType: " + printer.CurrentPaperType
                        + "\n Comment: " + printer.Comment
                        + "\n Caption: " + printer.Caption
                        + "\n ------------------------------------------------------------------------------------------------------"
                        );

               // Console.WriteLine(usbDevice.Name + " çalışır durumu:" + usbDevice.Status);

            }

            Console.Read();


            //ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath); //For the local Access
            //objScope.Connect();

            //SelectQuery selectQuery = new SelectQuery();
            //selectQuery.QueryString = "Select * from win32_Printer";
            //ManagementObjectSearcher MOS = new ManagementObjectSearcher(objScope, selectQuery);
            //ManagementObjectCollection MOC = MOS.Get();
            //foreach (ManagementObject mo in MOC)
            //{
            //    Console.WriteLine(
            //        "İsim: " + mo["Name"].ToString()
            //        + "\n Port Adı: " + mo["PortName"].ToString()
            //        + "\n Durumu: " + mo["Status"].ToString()
            //        + "\n StatusInfo: " + mo["StatusInfo"].ToString()
            //        + "\n SystemCreationClassName: " + mo["SystemCreationClassName"].ToString()
            //        + "\n PrinterState: " + mo["PrinterState"].ToString()
            //        + "\n PrinterStatus: " + mo["PrinterStatus"].ToString()
            //        + "\n PNPDeviceID: " + mo["PNPDeviceID"].ToString()
            //        + "\n DeviceID: " + mo["DeviceID"].ToString()
            //        + "\n Parameters: " + mo["Parameters"].ToString()
            //        + "\n Location: " + mo["Location"].ToString()
            //        + "\n LastErrorCode: " + mo["LastErrorCode"].ToString()
            //        + "\n ExtendedPrinterStatus: " + mo["ExtendedPrinterStatus"].ToString()
            //        + "\n ExtendedDetectedErrorState: " + mo["ExtendedDetectedErrorState"].ToString()
            //        + "\n ErrorDescription: " + mo["ErrorDescription"].ToString()
            //        + "\n DriverName: " + mo["DriverName"].ToString()
            //        + "\n DefaultPaperType: " + mo["DefaultPaperType"].ToString()
            //        + "\n DefaultCopies: " + mo["DefaultCopies"].ToString()
            //        + "\n CurrentPaperType: " + mo["CurrentPaperType"].ToString()
            //        + "\n Comment: " + mo["Comment"].ToString()
            //        + "\n Caption: " + mo["Caption"].ToString()
            //        + "\n ------------------------------------------------------------------------------------------------------"
            //        );
            //}
            
           
        }
    }
}
