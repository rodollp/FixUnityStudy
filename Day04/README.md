# 점프 액션 게임 (Unity 6)

## 프로젝트 소개

플레이어가 공을 조작해 스테이지를 진행하며 포인트 아이템을 수집하고, GoalPoint에 도달하는 3D 점프 액션 게임입니다.  
스테이지마다 점프 발판, 회전 장애물, SlowZone, NavMesh 안내봇 등 서로 다른 기믹을 배치했습니다.

이 프로젝트는 단순한 기능 구현뿐 아니라, `StageManager`, `BotManager`, `RespawnManager`, `UIManager`처럼 역할을 나누고 리팩터링하는 연습을 목표로 제작했습니다.

---

## 조작 방법

| 입력 | 동작 |
|---|---|
| WASD | 이동 |
| Space | 점프 |
| Start Button | 게임 시작 |
| Restart Button | 게임 재시작 |

---

## 주요 구현 기능

### 플레이어

- Input System 기반 키보드 입력 처리
- WASD 이동, Space 점프
- Rigidbody 기반 이동 및 점프
- Raycast를 이용한 바닥 체크
- 이동 방향에 따라 공 비주얼 회전
- SlowZone 진입 시 이동 속도 감소 및 복구
- KillZone 또는 장애물 접촉 시 RespawnManager를 통해 현재 스테이지 시작 지점으로 복귀

### 스테이지 시스템

- `StageData`를 이용한 스테이지별 데이터 관리
  - Stage Root
  - StartPoint
  - GoalPoint
  - PointItem Parent
  - GoalPoint 시작 활성화 여부
- `StageManager`를 통한 스테이지 시작, 전환, 초기화 처리
- 현재 스테이지를 제외한 나머지 스테이지 비활성화
- 스테이지 시작 시 포인트 아이템 재활성화
- 모든 포인트 획득 시 GoalPoint 활성화
- 클리어 시 다음 스테이지로 전환
- 마지막 스테이지 클리어 시 Clear UI 출력

### 포인트 / 아이템 시스템

- Trigger Collider를 이용한 포인트 아이템 획득
- 플레이어가 아이템에 닿으면 포인트 증가
- 획득한 아이템은 비활성화 처리
- 현재 포인트 / 필요 포인트를 UI에 표시
- 스테이지 재시작 시 포인트 아이템 상태 초기화

### GoalPoint 이벤트 구조

- `GoalPoint`는 직접 스테이지 전환이나 봇 처리를 실행하지 않고, 도착 사실만 이벤트로 알림
- 플레이어 도착 시 `OnPlayerCheck` 이벤트 발생
- 안내봇 도착 시 `OnBotCheck` 이벤트 발생
- `StageManager`가 플레이어 도착 이벤트를 받아 다음 스테이지로 전환
- `BotManager`가 봇 도착 이벤트를 받아 카메라와 플레이어 조작 상태를 복구

### UI 시스템

- 시작 화면, 게임 HUD, 클리어 화면 분리
- Start 버튼을 통한 게임 시작
- Restart 버튼을 통한 게임 재시작
- 현재 스테이지 번호 표시
- 현재 포인트 / 필요 포인트 표시
- 모든 스테이지 클리어 시 Clear UI 출력

### Respawn 시스템

- `RespawnManager`가 현재 스테이지의 StartPoint를 저장
- 스테이지 시작 시 플레이어를 StartPoint로 이동
- 리스폰 시 플레이어 위치, 회전, Rigidbody 속도 초기화
- KillZone과 장애물에서 공통으로 RespawnManager 호출

### NavMesh 안내봇

- `BotManager`가 안내봇 스테이지의 시작과 종료 흐름 담당
- `BotNavMesh`가 NavMeshAgent 이동 담당
- 안내봇은 스테이지 시작 시 StartPoint로 초기화 후 목표 지점으로 이동
- `ResetBot()`과 `StartBot()` 역할 분리
  - `ResetBot()` : 봇 활성화, 시작 위치 이동, 정지, 속도 초기화
  - `StartBot()` : 목표 지점으로 이동 시작
  - `HideBot()` : 이동 정지 후 비활성화
- 안내봇 이동 중에는 플레이어 조작 비활성화
- 안내봇 도착 후 플레이어 카메라로 전환하고 조작 활성화
- SlowZone 진입 시 안내봇 속도 감소 및 복구

### 카메라 시스템

- Cinemachine Camera 2개 사용
  - Player Camera
  - Bot Camera
- 안내봇 이동 중에는 Bot Camera 우선순위 증가
- 안내봇 도착 후 Player Camera 우선순위 증가
- 카메라 우선순위 전환은 `CameraValue`에서 관리

### 장애물 / 플랫폼 기믹

- 회전하는 프로펠러형 장애물 구현
- 장애물 접촉 시 KillZone과 동일하게 플레이어 리스폰
- 프리팹 인스턴스별 회전 속도 조절 가능
- SlowPlatform을 이용한 속도 감소 구간 구현
- 시작 발판, 일반 발판, 점프 발판, 위험 구역을 Material로 구분

---

## 사용 기술

- Unity 6
- C#
- Input System
- Rigidbody
- Trigger Collider
- Raycast
- Cinemachine
- NavMeshAgent
- TextMeshPro UI
- Prefab 기반 스테이지 구성

---

## 핵심 스크립트 역할

### StageManager

스테이지 흐름을 관리합니다.

- 게임 시작 / 재시작
- 현재 스테이지 활성화
- 포인트 아이템 초기화
- GoalPoint 활성화 상태 초기화
- 리스폰 위치 설정
- UI 갱신
- GoalPoint 이벤트 연결
- 특정 스테이지에서 BotManager 호출

### BotManager

안내봇 스테이지의 진행을 관리합니다.

- 현재 스테이지에서 BotNavMesh 검색
- 플레이어 조작 비활성화
- 봇 카메라 전환
- 봇 초기화 후 이동 시작
- 봇 도착 후 플레이어 조작 복구
- 플레이어 카메라 전환

### BotNavMesh

NavMeshAgent를 이용한 안내봇 이동을 담당합니다.

- 시작 위치로 이동
- 목표 지점으로 이동
- 이동 정지
- 속도 변경 및 복구
- 도착 후 비활성화

### GoalPoint

도착 판정을 담당합니다.

- 플레이어 도착 이벤트 발생
- 봇 도착 이벤트 발생
- 직접 StageManager나 BotManager를 실행하지 않고 이벤트만 전달

### RespawnManager

플레이어 리스폰을 담당합니다.

- 현재 스테이지 시작 위치 저장
- 플레이어 위치 / 회전 초기화
- Rigidbody 속도 초기화

### UIManager

UI 화면 전환과 텍스트 갱신을 담당합니다.

- 시작 UI
- 게임 HUD
- 클리어 UI
- 스테이지 텍스트
- 포인트 텍스트

---

## 구현하면서 학습한 내용

- Trigger Collider를 이용한 아이템 획득과 Goal 판정
- UI 버튼과 게임 흐름 연결
- NavMeshAgent의 `Warp`, `SetDestination`, `ResetPath`, `isStopped` 사용
- Cinemachine Camera Priority를 이용한 카메라 전환

