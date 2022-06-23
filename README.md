# Borit / Froelich XML-CSV Converter

## Table Of Contents
- [Borit / Froelich XML-CSV Converter](#borit--froelich-xml-csv-converter)
  - [Table Of Contents](#table-of-contents)
  - [Getting started](#getting-started)
    - [Run by hand](#run-by-hand)
      - [Example:](#example)
    - [Run using Task Scheduler](#run-using-task-scheduler)
  - [License](#license)

## Getting started
To install this program, find the latest release in the releases section and download the .EXE file.

Next, run the file and select a location where the program should be extracted to.  
For example: `C:\Borit-Froelich-XML-CSV-Converter`

The program is now installed to the system.

You can run it by hand, or using the Task Scheduler (`taskschd.msc`)

### Run by hand
You can run the program by hand using a terminal like `PowerShell` or `cmd`.

Running `C:\Borit-Froelich-XML-CSV-Converter\Converter.CLI.exe --help` will show you the options required to run the program.

To convert a bunch of XML files to CSV, the program needs 2 options:
- Source directory
- Destination directory

#### Example:  
Your source directory is located at `C:\input` and your output directory is located at `C:\output`.  
You would then run the following command: `C:\Borit-Froelich-XML-CSV-Converter\Converter.CLI.exe -s C:\input -d C:\output`  
The options `-s` and `-d` stand for source and destination correspondingly.

### Run using Task Scheduler


## License
This software is licensed under the MIT license.
