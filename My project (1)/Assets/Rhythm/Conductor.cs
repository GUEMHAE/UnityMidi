using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // �д� �뷡 ��Ʈ
    public float songBpm = 128;

    // �� �뷡 ��Ʈ�� �� ��
    public float secPerBeat;

    // ���� �뷡 ��ġ(��)
    public float songPosition;

    // ���� �뷡 ��ġ(��Ʈ ����)
    public float songPositionInBeats;

    // �뷡�� ���۵� �� �� �ʰ� �����°�
    public float dspSongTime;

    // �� GameObject�� ����Ǿ� ������ ����ϴ� AudioSource.
    public AudioSource musicSource;
    public float firstBeatOffset;

    // �� ������ ��Ʈ ��
    public float beatsPerLoop;

    // ��Ʈ ī���� (���� ��带 ���� Ÿ�̹� Ȯ�ο�)
    private int nextBeatToSpawn = 0;

    // ��� ������
    public GameObject notePrefab;

    // ��尡 ������ ��ġ
    public Transform noteSpawnPoint;

    public static Conductor instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // GameObject�� ÷�ε� AudioSource�� �ε��մϴ�.
        musicSource = GetComponent<AudioSource>();

        // �� ��Ʈ�� �� ���� ����մϴ�.
        secPerBeat = 60f / songBpm;

        // ������ ���۵Ǵ� �ð��� ����մϴ�.
        dspSongTime = (float)AudioSettings.dspTime;

        // ���� ����
        musicSource.Play();
    }

    void Update()
    {
        // �뷡�� ���� ��ġ(��)�� ���
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        // �뷡�� ���� ��ġ�� ��Ʈ�� ��ȯ
        songPositionInBeats = songPosition / secPerBeat;

        // ���� ��带 ������ �ð����� Ȯ��
        if (songPositionInBeats >= nextBeatToSpawn)
        {
            // ��� ����
            SpawnNote();

            // ���� ����� ���� �ð��� ����
            nextBeatToSpawn++;
        }
    }

    // ��带 �����ϴ� �Լ�
    void SpawnNote()
    {
        // ������ ��ġ�� ��� ������ ����
        Instantiate(notePrefab, noteSpawnPoint.position, noteSpawnPoint.rotation);
    }
}
