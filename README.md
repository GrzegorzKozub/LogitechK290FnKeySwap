# LogitechK290FnKeySwap

## Purpose

[Logitech Comfort Keyboard K290](http://www.logitech.com/en-au/product/comfort-keyboard-k290) function keys work as Windows 8 and multimedia keys by default. In order to get the normal function key behavior you need to hold the Fn key.

You can configure this using Logitech SetPoint software. This tool is for those who don't want to use SetPoint.

## Credits

This application is mostly a Windows port of [k290-fnkeyctl](https://github.com/milgner/k290-fnkeyctl) written by Marcus Ilgner. He's [figured out](http://marcusilgner.com/blog/2014/01/24/friday-night-hack-logitech-k290-on-linux/) what SetPoint does and how it can be done on Linux.

## Dependencies

This tool depends on two components:

* [libusb-win32](http://sourceforge.net/projects/libusb-win32) needs to be installed. I opted to install libusb-win32-devel-filter from [here](http://sourceforge.net/projects/libusb-win32/files/libusb-win32-releases/). Then I used `install-filter-win.exe` to add libusb-win32 driver to my K290 keyboard. It showed up on that tool's list with `vid:046d`, `pid:c31f` and `mi:00`. This is a one time setup.
* [LibUsbDotNet](http://sourceforge.net/projects/libusbdotnet/) is included and used as an abstraction layer over libusb-win32.

## Usage

Run `LogitechK290FnKeySwap.exe` to swap the Fn key or  `LogitechK290FnKeySwap.exe /reset` to put the Fn key to its default behavior.
