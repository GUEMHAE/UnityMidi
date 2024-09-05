using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // 분당 노래 비트
    public float songBpm = 128;

    // 각 노래 비트의 초 수
    public float secPerBeat;

    // 현재 노래 위치(초)
    public float songPosition;

    // 현재 노래 위치(비트 단위)
    public float songPositionInBeats;

    // 노래가 시작된 후 몇 초가 지났는가
    public float dspSongTime;

    // 이 GameObject에 연결되어 음악을 재생하는 AudioSource.
    public AudioSource musicSource;
    public float firstBeatOffset;

    // 각 루프의 비트 수
    public float beatsPerLoop;

    // 비트 카운터 (다음 노드를 찍을 타이밍 확인용)
    private int nextBeatToSpawn = 0;

    // 노드 프리팹
    public GameObject notePrefab;

    // 노드가 생성될 위치
    public Transform noteSpawnPoint;

    public static Conductor instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // GameObject에 첨부된 AudioSource를 로드합니다.
        musicSource = GetComponent<AudioSource>();

        // 각 비트의 초 수를 계산합니다.
        secPerBeat = 60f / songBpm;

        // 음악이 시작되는 시간을 기록합니다.
        dspSongTime = (float)AudioSettings.dspTime;

        // 음악 시작
        musicSource.Play();
    }

    void Update()
    {
        // 노래의 현재 위치(초)를 계산
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        // 노래의 현재 위치를 비트로 변환
        songPositionInBeats = songPosition / secPerBeat;

        // 다음 노드를 생성할 시간인지 확인
        if (songPositionInBeats >= nextBeatToSpawn)
        {
            // 노드 생성
            SpawnNote();

            // 다음 노드의 생성 시간을 설정
            nextBeatToSpawn++;
        }
    }

    // 노드를 생성하는 함수
    void SpawnNote()
    {
        // 지정된 위치에 노드 프리팹 생성
        Instantiate(notePrefab, noteSpawnPoint.position, noteSpawnPoint.rotation);
    }
}
