using MidiJack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MIDIController : MonoBehaviour
{
 void Update()
    {
        // ��� MIDI ��Ʈ(��: 0-127)�� �˻�
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
