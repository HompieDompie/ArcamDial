ArcamDial v1.0

With ArcamDial you can control your Arcam amplifier with a Microsoft Surface Dial.
The idea for this is borrowed from rooDial (www.rooextend.com), which is a great tool 
but it requires Roon. 


*** What you need ***
- Arcam SA30 amplifier. The SA10 and SA20 might also work (untested), although not
  all settings available in the program will be applicable to them.

- Window 10 PC with a Microsoft Surface Dial connected to the pc. Because it uses
  Bluetooth you might need to purchase a USB Bluetooth dongle. These are quite cheap
  though.

*** Installation ***
- Copy the executable ArcamDial.exe somewhere on the PC, and start it.

*** Usage ***
- The program will try to locate all Arcam devices in your network, and show their
  ip-addresses in the pulldown. Click on "Connect" and the fields below should get
  populated with info from your amplifier.

- The sensitivity of the volume control can have a value of 1 to 30. Higher means more
  sensitive. If you have haptic feedback enabled ("clicky" feeling when you rotate the 
  dial) and a high sensitiviy, but want to have fewer clicks, increase the Vol/clicks
  setting.

- Now select what functionality you want to link to the Surface Dial click and rotate 
  options. Just the normal rotate can't be setup, it is always linked to controlling
  the volume.

- Because Window sees the Surface Dial as an input device, it commands will only
  get send to the active window (just like a keyboard or mouse). Therefore ArcamDial
  must always be the active Window when you're using the dial to control the amp.
  So no, you can't use the pc actively for other things. In my case I'm just using it
  as a music streamer, then it's no problem.
  To prevent other windows to steal the input control, check the "Force" checkbox. It
  will force this program to be on top and having the focus.


*** Notes ***
- If you haven't done so already, please set a sensible maximum volume on your amp.
  It will save you (and your speakers) one day...


*** Known problems ***
- Although the program shows the installed Dirac filter names, it doesn't know what the
  active one is. The amp sometimes returns the correct value, but most of the times
  it says Dirac is not activated even though it is. (Using V1.41 on SA30)

- The Standby/Wake option can only set the amp to Standby, waking it up doesn't work.
  (Even if Network standby option on the amp is enabled).

- The dial has an inbuild timeout of 5 minutes. It wakes up when you click or rotate it,
  but that event sometimes gets send to the program, sometimes not. I'm not sure why.

  

