# JJHKiosk 소개

해당 프로젝트는 Prism 프레임워크를 사용하여 WPF 설계를 디자인하고, EFCore를 사용해 MariaDB와 연동하여

각종 데이터를 불러와 KIOSK앱에 적용하여 작동하게 하는 앱을 제작하는 프로젝트입니다.

------

## 사용 기술

- C#(8.0)
- WPF
- EntityFrameworkCore(v8.0.10)
- Prism(9.0.537)
- CommunityToolkit.Mvvm(8.3.2)

------

## 테스트용 아이디/비밀번호

 ID : guest
 PW : 1234guest

------

## 테스트방법 

1. GitHub에서 파일을 다운로드 또는 Clone.
2. dump-JJH_KioskDB-202510091809.sql 파일을 mysql에 Restore합니다. (해당 파일은 DBeaver에서 백업한 파일이므로 되도록 DBeaver에서 Restore해주시기 바랍니다.)
3. 앱 실행
4. 첫화면에서 ID를 guest 비밀번호를 1234guest 를 입력하여 실행
5. 현재는 완전한상태가아니고 디자인만 어느정도 진행된 상태입니다. 메뉴를 클릭하고 아이템을 선택하고 추가 옵션을 선택하는 화면까지만 구현되어 있습니다.

------

## 프로젝트 설명

### DB설계

![DB ERD 이미지](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/ERD.png)

MariaDB에 구성할 DB의 설계도입니다.

기본적으로 로그인할 ID와 해당 ID에 연계된 StoreID를 할당하고

Store의 정보를 담당하는 테이블과 그에 종속된 메뉴그리고 메뉴에 종속된 옵션등등의 데이터를 구성하였습니다.

### 실제DB 구현
![실제 구성한 DB](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/DBImage.png)

DB 설계와 거의 동일하게 MariaDB에 테이블과 컬럼을 작성하였습니다.

### DB의 위치
![DB 설치 장비](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/SynologyDBServer.png)

DB는 같은 컴퓨터가 아닌 같은 네트워크 내에 있는 NAS서버에 설치하여 내부 IP의 포트를 열어 연결하여 사용하였습니다.

