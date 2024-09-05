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

    void KeyPress()
    {
        int[] launchPadNotes = new int[] { 40, 41, 42, 43, 48, 49, 50, 51, 36, 37, 38, 39, 44, 45, 46, 47 };
        int[] keyboardNotes = new int[] { 48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72 };

        // 다이얼 CC 번호 (앞 6개는 95, 나머지 104, 109)
        int[] dialCCNumbers = new int[] { 95, 95, 95, 95, 95, 95, 104, 109 };
        foreach (int note in launchPadNotes)
        {
            float padValue = MidiMaster.GetKey(note);
            if (padValue > 0)
            {
                Debug.Log("Launchpad key " + note + " pressed with value: " + padValue);
            }
        }

        // 키보드 범위 확인
        foreach (int note in keyboardNotes)
        {
            float keyValue = MidiMaster.GetKey(note);
            if (keyValue > 0)
            {
                Debug.Log("Launchpad key " + note + " pressed with value: " + keyValue);
            }
        }

        // 다이얼 값 확인
        for (int i = 0; i < dialCCNumbers.Length; i++)
        {
            float ccValue = MidiMaster.GetKnob(dialCCNumbers[i]);

            if (ccValue > 0)
            {
                Debug.Log("Dial " + (i + 1) + " (CC " + dialCCNumbers[i] + ") turned with value: " + ccValue);
            }
        }
    }
}
