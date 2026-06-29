# 점프 액션 게임 (Unity 6)

## 프로젝트 소개

플레이어가 공을 조작하여 점프맵을 통과하고, 모든 포인트를 수집한 뒤 골인지점까지 도달하는 3D 점프 액션 게임입니다.

---

# 구현 기능

## 플레이어

- Input System을 이용한 이동
- Rigidbody를 이용한 물리 이동
- Rigidbody를 이용한 점프 구현
- Raycast를 이용한 바닥 체크
- Cinemachine을 이용한 카메라 추적

---

## 스테이지

- StageData를 이용한 스테이지 데이터 관리
- StageManager를 이용한 스테이지 진행 관리
- Stage별 시작 위치(StartPoint) 설정
- Stage별 GoalPoint 관리
- Stage별 PointItem 자동 개수 계산

---

## 포인트 시스템

- Trigger를 이용한 아이템 획득
- 아이템 획득 시 자동 삭제
- 현재 획득 포인트 관리
- 모든 포인트 획득 시 GoalPoint 활성화

---

## Goal 시스템

- GoalPoint Trigger 구현
- Goal 도착 시 다음 스테이지 진행
- 마지막 스테이지 클리어 처리

---

## 리스폰 시스템

- RespawnManager 분리
- Stage마다 시작 위치 저장
- KillZone을 이용한 낙사 판정
- 플레이어 위치 및 Rigidbody 초기화

---

## 레벨 디자인

- Stage를 Prefab 단위로 관리
- Platform을 이용한 점프맵 구성
- Platform 위 포인트 배치
- 공중 포인트 배치
- GoalPoint를 이용한 목표 지점 구성

---

## 엔진 기능 활용

- Rigidbody
- Trigger Collider
- Raycast
- Cinemachine
- Material
- Emission Material
- UI(구현 예정)
- NavMesh(구현 예정)

---

## 프로젝트 구조

```
Managers
├── StageManager
├── RespawnManager
└── UIManager (예정)

Player
├── Rigidbody
├── PlayerInputHandle
├── PlayerMove
├── GroundCheck
└── CameraTarget

Stages
├── Stage_01
├── Stage_02
└── Stage_03
```

---

## 사용 기술

- Unity 6
- C#
- New Input System
- Rigidbody Physics
- Trigger
- Raycast
- Cinemachine