using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CyUSB;

namespace JLusb
{
    public class JLusb
    {
        private USBDeviceList mUSBDevList;
        private CyUSBDevice mCyUSBDev;
        private CyUSBEndPoint mCyUSBInEP;
        private CyUSBEndPoint mCyUSBOutEP;
        private byte[] mFrame = new byte[512];

        public JLusb()
        {
            mUSBDevList = new USBDeviceList(CyConst.DEVICES_CYUSB);
            mUSBDevList.DeviceAttached += new EventHandler(mUSBDevList_Attached);
            mUSBDevList.DeviceRemoved += new EventHandler(mUSBDevList_Removed);
            if (mUSBDevList.Count > 0)
            {
                USBDetected();
            }
        } // end public JLusb()
        /// <summary>
        /// detected the usb is attaching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mUSBDevList_Attached(Object sender, EventArgs e)
        {
            USBDetected();
        } // end private void mUSBDevList_Attached(Object sender, EventArgs e)
        /// <summary>
        /// detected the usb is removing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mUSBDevList_Removed(Object sender, EventArgs e)
        {
            mCyUSBDev.Dispose();
            mUSBDevList.Dispose();
            mUSBDevList.DeviceAttached -= mUSBDevList_Attached;
            mUSBDevList.DeviceRemoved -= mUSBDevList_Removed;
        } // end private void mUSBDevList_Removed(Object sender, EventArgs e)
        /// <summary>
        /// function for all detected thing
        /// </summary>
        private void USBDetected()
        {
            mCyUSBDev = mUSBDevList[0x04b4, 0x1004] as CyUSBDevice;
            if (mCyUSBDev == null)
            {
                MessageBox.Show("No Such Device!");
            }
            else
            {
                //mCyUSBInEP = mCyUSBDev.BulkInEndPt;
                mCyUSBOutEP = mCyUSBDev.BulkOutEndPt;

                foreach (CyUSBEndPoint ept in mCyUSBDev.EndPoints)
                {
                    if (ept.bIn && (ept.Attributes == 2))
                    {
                        mCyUSBInEP = ept as CyBulkEndPoint;
                    }
                }
            }
        } //private void USBDetected()
        public bool get_video()
        {
            int len = 512;
            bool received = false;
            if (mCyUSBInEP != null)
                received = mCyUSBInEP.XferData(ref mFrame, ref len);
            return received;
        }
    } // end public class JLusb

} // end namespace JLusb