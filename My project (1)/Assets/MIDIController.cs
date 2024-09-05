using MidiJack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MIDIController : MonoBehaviour
{
 void Update()
    {
        // 모든 MIDI 노트(예: 0-127)를 검사
        for (int note = 0; note < 128; note++)
        {
            float value = MidiMaster.GetKey(note);
            if (value > 0.5f)
            {
                Debug.Log($"MIDI Note {note} is pressed.");
            }
        }
    }



}
