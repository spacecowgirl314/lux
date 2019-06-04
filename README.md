# lux

> The SI unit of illuminance, equal to one lumen per square metre.

`lux` is a cli tool for controlling the brightness of external monitors that use DDC.

## Features
- Set monitor brightness
- Set monitor contrast
- Multiple monitor support

## Installation

See [releases](https://github.com/cybercatgurrl/lux/releases) for pre-built binaries.

## Using Chocolatey:
`choco install lux`

## Usage
Run `lux --help` to see options.


Lux uses set and get verbs. Values must be between 0 and 100.

## Caveats
- Does not work over SSH. This is due to a limitation of the Win32 API being used. 
- Capability checking has not been implemented since I encountered a bug when attempting to use it.

## Acknowledgements
Wouldn't be possible without the work to translate the calls to the Win32 API by Alexander Horn in DisplayConfiguration.cs.