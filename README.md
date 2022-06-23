# Borit / Froelich XML-CSV Converter

## Table Of Contents
- [Borit / Froelich XML-CSV Converter](#borit--froelich-xml-csv-converter)
  - [Table Of Contents](#table-of-contents)
  - [Getting started](#getting-started)
    - [Run by hand](#run-by-hand)
      - [Example](#example)
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

#### Example
Your source directory is located at `C:\input` and your output directory is located at `C:\output`.  
You would then run the following command: `C:\Borit-Froelich-XML-CSV-Converter\Converter.CLI.exe -s C:\input -d C:\output`  
The options `-s` and `-d` stand for source and destination correspondingly.

### Run using Task Scheduler
Start by opening the Task Scheduler (Win+R -> `taskschd.msc`).  

Next, create a new task.  
1. Open the `General` tab.
2. Give this task a meaningful name.
3. If needed, under security options, change the user to run this program as, remember to set the user as allowed to the input and output directory as well.
4. Under security options, select `Run whether user is logged on or not`
5. Open the `Triggers` tab.
6. Create a new trigger.
7. Set `Begin the task` to `On a schedule`.
8. Choose the required trigger time and don't forget to set it to daily/weekly/monthly, else the task will only run **once**.
9. Check the box `Repeat task every` if you need it to run multiple times a day.
10. Make sure to `Enable` the trigger.
11. Click on OK.
12. Open the `Actions` tab.
13. Add a new action.
14. Set `Action` to `Start a program`.
15. Set `Program/script` to the install location and the executable called `Converter.CLI.exe`.
16. Add the arguments `-s` and `-d` to specify the input and output directories. Example: `-s C:\input -d C:\output`.
17. Save the task.

You're done!

The software should now be automatically invoked by the task scheduler in the time frame you have chosen.

## License
This software is licensed under the MIT license.
