// Program: Nano Timers
// Author:  GhostRavenstorm
// Date:    2017-07-22
// Ver:     1.1.0beta
//
// Summary: Timer library that includes countdown timers and stopwatches.


using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace NanoTimers{

// Summary:
// Timer class that counts from 0 to infinity in minutes and seconds.
//
// Remarks:
// Does not make event calls.
//
public class Stopwatch : Timer{

   // Summary:
	// Initializes the timer with default vaules and references.
	//
	// Remarks:
	// Not required to be called for the timer to function.
   // Is required to be called if live UI is desired.
	//
   public void Initialize(Text timerText){
      m_timerText = timerText;
      m_state = ETimerState.New;
      m_isInitialized = true;
   }

   void FixedUpdate(){
		switch(m_state){
			case ETimerState.Active:{

				m_millis += (int)(UnityEngine.Time.fixedDeltaTime * 1000);

				if(m_millis > 999){
					m_millis = 0;
					m_seconds += 1;
				}

				if(m_seconds > 59){
					m_seconds = 0;
					m_minutes += 1;
				}

				UpdateUI();

				break;
			}
		}
	}

} // End of class.

} // End of namespace.
