using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using System.Net;
using System.Windows;
using System.Device.Location;

namespace TestApp.Scripts
{
    class GPS
    {
        public static String Latitude = "0.00";
        public static String Longitude = "0.00";

        private static GeoCoordinateWatcher GPSLoc = null;

        public static void getGPS()
        {
            try
            {
                GPSLoc = new GeoCoordinateWatcher();
                GPSLoc.StatusChanged += GPSLocStatusChange;
                GPSLoc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("getGPS => " + ex.Message);
                return;
            }
        }

        private static void GPSLocStatusChange(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                if (GPSLoc.Position.Location.IsUnknown)
                {
                    MessageBox.Show("GPS", "Cannot find location data");
                }
                else
                {
                    GeoCoordinate location = GPSLoc.Position.Location;
                    MessageBox.Show("GPS", location.Latitude.ToString()+"="+location.Longitude.ToString());
                }
            }
        }
    }
}
