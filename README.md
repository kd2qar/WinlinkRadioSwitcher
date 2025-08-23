# WinlinkRadioSwitcher

Winlink does not support multiple radio configurations.
This tool can help you manage winlink settings for different radios.
It will copy and archive the radio settings from the winlink settings.
They can be saved under separate names and then copied back into the winlink settings when needed.
For example:
Three radios:

* Yaesu FT-991/A
* ICOM 7300
* Yaesu FT-818

You can save the settings from winlink for each radio and restore them when needed. It will save the settings for vara and ardop as configured. 
When you switch radios you can use this tool to copy in the settings for that radio you have previously saved. 

This only saves the TNC settings that winlink manages. It does not touch the settings managed by Vara or Ardop. 
You will need to restore the soundcard setting in each of those TNCs separately.

You could also use this to move settings between computers by copying the .ini file. Everything is saved in plain text '.ini' file format
so you can also copy and paste the settings using any text editor as well.

Note that this is a work in progress but it does accomplish the main purpose of swapping radio settings in and out of winlink.
Also it creates backups of the Winlink settings file "RMS Express.ini" each time it modifies the file.
You can view the saved settings but if you need to modify them, you will still need to do that in Winlink and then copy them back to your saved pool.
It's a pretty crude program, no bells and whistles and probably some bugs so 'Wear a Helmet!'

