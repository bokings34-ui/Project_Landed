<div align="center">

# 🌊 Landed

### *Run on the land, Revenge for the ocean.*

![Unity](https://img.shields.io/badge/Engine-Unity_6.3-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/Language-C%23-6A5ACD?style=for-the-badge&logo=csharp)
![Platform](https://img.shields.io/badge/Platform-PC-4682B4?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Developing-2E8B57?style=for-the-badge)

> 해양생물이 환경오염에 대한 복수를 위해 육지를 향해 달려가는  
> **2D 횡스크롤 러닝 액션 게임**

</div>

---

## 🎮 About The Project

**Landed**는 자동으로 전진하는 캐릭터를 조작하여  
지속적으로 감소하는 체력을 관리하면서  
장애물을 피하고 자원을 수집해 목적지까지 도달하는  
**2D 횡스크롤 러닝 액션 개인 프로젝트**입니다.

단순한 러닝 게임 구조에 그치지 않고,

- 체력 감소 기반 생존 압박
- 거리 기반 클리어 목표
- 랜덤 장애물 패턴
- 아이템 활용
- 캐릭터 / 부적 조합

요소를 결합하여 전략적인 플레이를 구현하는 것을 목표로 합니다.

---

## 🎯 Core Gameplay

| 구분 | 내용 |
|------|------|
| Character Move | Auto Run / Double Jump / Sliding |
| Survival Rule | Continuous HP Drain / Collision Damage |
| Collection | Bubble(Score) / Coin(Currency) / Heal Item |
| Growth | Character Select / Talisman Equip / Shop Upgrade |
| Goal | Reach destination before HP reaches zero |

---

## ✨ Key Features

- **생존형 체력 시스템**  
  시간 경과 및 충돌에 따라 체력이 감소하는 긴장형 플레이

- **랜덤 장애물 생성 시스템**  
  진행 구간마다 장애물 패턴을 순차 배치하여 반복 플레이 유지

- **자원 수집 및 상점 시스템**  
  점수와 재화를 수집하고 아이템 구매 및 강화를 진행

- **선택형 성장 요소**  
  캐릭터와 부적 조합으로 플레이 전략 변화

---

## 🛠️ Tech Stack

| Category | Used |
|----------|------|
| Engine | Unity 6.3 |
| Language | C# |
| IDE | Visual Studio |
| Version Control | GitHub |

---

## 📂 Data Structure Application

게임 시스템의 주요 데이터를 효율적으로 관리하기 위해  
다음과 같은 자료구조를 실제 로직에 적용하였습니다.

| Managed Data | Data Structure | Purpose |
|--------------|----------------|---------|
| 필드 내 생성 오브젝트 목록 | `List` | 버블, 코인, 장애물의 동적 생성/삭제 관리 |
| 캐릭터 및 부적 선택 슬롯 데이터 | `Array` | 고정된 선택 데이터 인덱스 접근 |
| 아이템 ID별 효과 및 수치 데이터 | `Dictionary` | 아이템 식별값 기반 정보 조회 |
| 다음에 등장할 장애물 패턴 순서 | `Queue` | 자연스러운 선입선출 스폰 처리 |
| 최근 적용된 버프 및 임시 효과 기록 | `Stack` | 마지막 상태부터 순차 해제 및 복구 |

---

## 🚀 Development Status

### Current Implementation Target
- Player Movement System
- HP Drain & Collision System
- Random Spawn System
- Score / Currency System
- Item Interaction System
- UI System

### Additional Plan
- Skill System
- Shop & Upgrade
- Theme Transition
- Reward System

---

## 👨‍💻 Developer

**Personal Unity 2D Game Project**

---
