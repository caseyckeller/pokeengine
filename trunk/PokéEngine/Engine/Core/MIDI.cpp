/*
Here's a sound loader/driver for the pokemon game. 
currently, because I'm lazy, it uses mciSendString() to play a MIDI in C++
mp3, ogg, etc. support will come later. 
Be sure to link with the Winmm.lib file, or this won't work!

THIS IS MOSTLY JUST AN EXAMPLE RIGHT NOW. 
IT WONT HAVE ANY REAL USE UNTIL WE START DESIGNING MAP AREAS.
SO, ITS NOT EVEN CLOSE TO DONE YET. 

ACTUALLY, YOU COULD JUST CONSIDER THIS TO BE A PLACEHOLDER FOR NOW.
YEAH, THAT'D BE GOOD.

by Brenden Homan
29 September 2010
*****
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*****
*/

#include <iostream.h>
#include <windows.h>
#include <mmsystem.h> //mciSendString()
#include <conio.h>

using namespace std; //std::cout, std::cin

int main()
{
char wait;
	
mciSendString("play C:\\Windows\\Media\\onestop.mid", NULL, 0, NULL); 
getch(); //wait
mciSendString("stop C:\\Windows\\Media\\onestop.mid", NULL, 0, NULL);
return 0;
}
	