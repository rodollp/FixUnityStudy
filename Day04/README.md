# 점프 액션 게임 (Unity 6)

## 프로젝트 소개

플레이어가 공을 조작해 스테이지를 진행하며 포인트 아이템을 수집하고, GoalPoint에 도달하는 3D 점프 액션 게임입니다.  
스테이지별로 점프 발판, 회전 장애물, SlowZone, NavMesh 안내봇 등 다른 기믹을 배치했습니다.

---

## 주요 구현 기능

### 플레이어
- New Input System을 이용한 이동/점프 입력 처리
- Rigidbody 기반 이동 및 점프
- Raycast를 이용한 바닥 체크
- KillZone 및 장애물 접촉 시 RespawnManager를 통한 위치 초기화

### 스테이지 시스템
- StageData를 이용한 스테이지별 데이터 관리
- StageManager를 통한 스테이지 전환
- 스테이지별 StartPoint, GoalPoint, PointItem 관리
- 모든 포인트 획득 시 GoalPoint 활성화
- 일부 스테이지는 GoalPoint를 시작부터 활성화 가능

### 아이템 / 포인트 시스템
- Trigger Collider를 이용한 포인트 아이템 획득
- 획득한 아이템 비활성화
- UI에 현재 포인트 / 필요 포인트 표시

### UI 시스템
- 시작 화면, 게임 HUD, 클리어 화면 분리
- Start 버튼을 통한 게임 시작
- 스테이지 번호 및 포인트 수 표시
- 클리어 시 Clear UI 출력

### NavMesh 안내봇
- NavMeshAgent를 이용한 안내봇 이동
- NavMeshSurface를 이용한 이동 가능 영역 구성
- NavMeshObstacle을 이용한 장애물 회피
- NavMesh Link를 이용한 끊어진 구간 이동
- SlowZone 진입 시 안내봇 속도 감소 및 원래 속도 복구
- Cinemachine 카메라 전환을 통해 안내봇 이동 경로 확인 후 플레이어 조작 시작

### 장애물
- 회전하는 프로펠러형 장애물 구현
- 장애물 접촉 시 KillZone과 동일하게 플레이어 리스폰
- 프리팹 인스턴스별 회전 속도 조절 가능

---

## 사용 기술

- Unity 6
- C#
- New Input System
- Rigidbody Physics
- Trigger Collider
- Raycast
- Cinemachine
- NavMesh
- TextMeshPro UI

---

## 프로젝트 구조

```text
Managers
├── StageManager
├── RespawnManager
└── UIManager

Player
├── PlayerInputHandle
├── PlayerMove
├── GroundCheck
└── CameraTarget

Navigation
├── BotNavMesh
├── NavMeshSurface
├── NavMeshObstacle
└── NavMeshLink

Stages
├── Stage_01
├── Stage_02
└── Stage_03

UI
├── StartUI
├── GameUI
└── ClearUI