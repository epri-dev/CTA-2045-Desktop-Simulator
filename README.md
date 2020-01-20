# ABSTRACT
The ANSI/CTA-2045-A simulator software acts as a smart grid device (SGD) or universal communications module (UCM) to aid in the development and test of new and existing technologies that exchange information through an ANSI/CTA-2045-A interface. 

## Description
This application provides a fully functional simulator for both SGDs and UCMs. Using different cable sets, both AC and DC form factors are supported. This manual describes how to use this software to emulate both device types as well as all three message categories of data link, basic demand response (DR) messages, and intermediate DR messages.

## Benefits and Value
This application has several uses to benefit utilities, manufacturers, and vendors:
* **Simulate an SGD.** In this mode, the application can be used to test UCMs to evaluate their compliance with the ANSI/CTA-2045-A standard.
* **Simulate a UCM.** In this mode, the application can be used to test SGDs to evaluate their compliance with the ANSI/CTA-2045-A standard.
* **Simulate both SGD and UCM.** In this mode, the application can act as a tutor for developers who are unfamiliar with the ANSI/CTA-2045-A standard in understanding how to implement the standard by viewing example exchanges and performing what-if testing.
* **Act as an automated test system.** Using the test script mode, repetitive testing can be simplified and allow product testing with minimal human involvement.

This simulator application may assist in reducing the cost of product evaluations, development, and testing.

## Platform Requirements
This software has been tested on Microsoft Windows 10 and Windows 7, both 32- and 64-bit. It should also operate on all current Microsoft platforms such as Windows Vista and Windows 8.

## Building Executable from source code
The step by step instructions to build the executable can be found in the user manual located in "cta-2045-desktop-simulator/Manual/AINSICTA-2045-A_Simulator_User_Guide_Production_19.08.22.pdf" ( See Section 3 - INSTALLATION AND STARTUP.)
* Install Visual Studio IDE or any IDE capable of building Visual Studio's solution project
* Execute git clone https://github.com/epri-dev/CTA-2045-Desktop-Simulator.git from a local directory or download and extract CTA-2045-Desktop-Simulator-master.zip to a local directory
* Navigate to the directory and open the file name "CTA2045Sim.sln"; Visual Studio or the IDE should load the project.
* Under the Build menu, click on either Publish CTA2045Sim or Build CTA2045Sim and wait for the process to complete
* The executable files will be in the local directory at "publish/setup.exe", "obj/x86/Debug/CTA2045Sim.exe", "obj/x86/Release/CTA2045Sim.exe", "bin/Release/CTA2045Sim.exe" or "bin/Debug/CTA2045Sim.exe."

Once run, the executable will either start the simulator or start a setup wizard before starting the simulator.

## Getting Executable from repository
The executables built from Visual Studio were archived into [CTA-2045-A.zip](https://github.com/epri-dev/CTA-2045-Desktop-Simulator/releases/download/19.08.22/CTA-2045-A.zip) 
* Download and extract CTA-2045-A.zip to a local directory
* Navigate to the local directory
* The executable files are at "publish/setup.exe", "obj/x86/Debug/CTA2045Sim.exe", "obj/x86/Release/CTA2045Sim.exe", "bin/Release/CTA2045Sim.exe" or "bin/Debug/CTA2045Sim.exe."

Running any of the executables will either start the simulator immediately or go through a setup wizard before starting the simulator.

## Keywords
ANSI/CTA-2045-A  
CEA-2045  
CTA-2045  
Demand response  
Simulator  
Smart grid device (SGD)  
Universal communication module (UCM)  
