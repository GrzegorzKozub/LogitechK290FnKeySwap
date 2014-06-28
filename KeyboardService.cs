namespace GrzegorzKozub.LogitechK290FnKeySwap
{
    using System;
    using LibUsbDotNet;
    using LibUsbDotNet.Main;

    internal static class KeyboardService
    {
        private enum FnKeyMode : short
        {
            Default = 0,
            Swapped = 1
        }

        internal static void SwapFnKey()
        {
            SetFnKeyMode(FnKeyMode.Swapped);
        }

        internal static void ResetFnKey()
        {
            SetFnKeyMode(FnKeyMode.Default);
        }

        private static void SetFnKeyMode(FnKeyMode mode)
        {
            UsbDevice keyboard = null;

            try
            {
                keyboard = UsbDevice.OpenUsbDevice(new UsbDeviceFinder(0x046d, 0xc31f));

                if (keyboard == null)
                {
                    throw new KeyboardNotFoundException("Could not find Logitech K290 device. It's not connected or libusb-win32 is not installed.");
                }

                var setupPacket = new UsbSetupPacket(0x40, 2, 0x001a, (short)mode, 0);
                int sentBytesCount;

                if (keyboard.ControlTransfer(ref setupPacket, null, 0, out sentBytesCount) == false)
                {
                    throw new ApplicationException(
                        string.Format(
                            "Error transferring control data to the device. Code: {0}. Message: {1}.",
                            UsbDevice.LastErrorNumber,
                            UsbDevice.LastErrorString));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (keyboard != null)
                {
                    keyboard.Close();
                }

                UsbDevice.Exit();
            }
        }
    }
}
