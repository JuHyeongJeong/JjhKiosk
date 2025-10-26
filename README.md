# JJHKiosk 소개

해당 프로젝트는 Prism 프레임워크를 사용하여 DI를 적용, MVVM 방식으로 WPF 설계를 디자인하고, EFCore를 사용해 MariaDB와 연동하여

각종 데이터를 불러와 KIOSK앱에 적용하여 작동하게 하는 앱을 제작하는 프로젝트입니다.

------

## 사용 기술

- C#(8.0)
- WPF
- EntityFrameworkCore(v8.0.10)
- Prism(9.0.537)
- CommunityToolkit.Mvvm(8.3.2)
- MariaDB(개인용 NAS서버에 설치)

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

![DB ERD 이미지](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/ERD.png)

MariaDB에 구성할 DB의 설계도입니다.

기본적으로 로그인할 ID와 해당 ID에 연계된 StoreID를 할당하고

Store의 정보를 담당하는 테이블과 그에 종속된 메뉴그리고 메뉴에 종속된 옵션등등의 데이터를 구성하였습니다.

### 실제DB 구현
![실제 구성한 DB](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/DBImage.png)

DB 설계와 거의 동일하게 MariaDB에 테이블과 컬럼을 작성하였습니다.

### DB의 위치

![DB 설치 장비](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/SynologyDBServer.png)

DB는 같은 컴퓨터가 아닌 같은 네트워크 내에 있는 NAS서버에 설치하여 내부 IP의 포트를 열어 연결하여 사용하였습니다.


### 화면설계

![화면설계](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/modeling.png)

초기 기획했던 설계화면입니다.

본래 우측과 하단에 아이템 표시 부분을 할당하려했으나, 팝업화면으로 아이템 표시하는게 더 나은것같아서 변경하였습니다.



### 실기화면


![로그인 화면](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/1.png)

로그인화면입니다. 해당 화면에서 DB의 Kiosk_Account 테이블에 저장되어있는 아이디와 비밀번호를 입력해야 합니다.




![로그인 정보 DB](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/1_1.png)

이때 비밀번호는 해쉬값으로 변환되어 저장되어있으므로 DB를 본다고 값을 알수는 없습니다.

프로젝트내에 Utility폴더 내에 있는 PasswordHashGenerator 프로젝트를 실행하여 원하는 비밀번호를 삽입하면 해쉬값 변경이 가능하니

여기서 변경 후 DB에 저장하면 됩니다.





![포장_테이크아웃선택](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/2.png)

음료를 홀에서 마실지 가져갈지 선택하는 화면입니다.





![메뉴화면](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/3.png)

메뉴선택화면입니다.

로그인한 계정의 DB정보에 StoreID를 보고

해당 Store에 있는 메뉴를 가져와서 상위 컬럼에 맞는 메뉴를 삽입합니다.

메뉴별로 DB에 이미지 위치가 저장되어있고, 프로젝트중 Resource를 담당하는 프로젝트에서 위치를 찾아 이미지를 띄워줍니다.






![상단 배너 애니메이션](https://github.com/user-attachments/assets/b5d56746-9bd8-48ce-9544-d047e4f39ff8)

상단 배너는 3초마다 다른이미지로 넘어갑니다. 우측에서 좌측으로 이동하며, 3개의 이미지를 반복해서 보여줍니다.
해당이미지가 움직이지 않는다면 이미지를 클릭해주세요.





![옵션 화면](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/4.png)

메뉴의 추가할 옵션을 선택합니다.


------

## 프로젝트 구성 설명

![VisualStudio프로젝트들](https://github.com/JuHyeongJeong/JjhKiosk/blob/main/mdImages/project.png)

프로젝트는 위와같이 구성되어있습니다.

폴더

** LIB

- 라이브러리를 저장하는 폴더


** UI

- 중심이되는 UI 프로젝트와 그 구성요소 프로젝트들을 저장하는 폴더


** Utility

- 프로젝트 구성에 필요하진 않지만 유용하게 사용할 수 있는 유틸리티 프로젝트 저장 경로


------


*** 그리고 각 프로젝트는 다음과 같은 기능을 담당합니다.

### LIB

1. JjhKiosk.DB.Server.EF.Core : EntityFrameworkCore 라이브러리를 이용하여 MSSQL/MySQL(MariaDB)에 연결하여 데이터를 가져오거나 업데이트할 수 있는 프로젝트


### UI

1. JjhKiosk : 중심이되는 메인 프로젝트. Config를 담당하는 Json파일과, 모든 모델, View, ViewModel을 DI 컨테이너에 등록합니다.
  
   그리고 View와 ViewModel의 DataContext의 관계를 연결하고, 공동으로 사용하는 Color나 Size등의 Resource값을 모든

   프로젝트에서 공통으로 사용할 수 있도록 등록하여 관리합니다. 프로그램의 시작점으로 메인 윈도우를 띄웁니다.

   
2. JjhKiosk.Login : 로그인 화면 디자인입니다.

   로그인에 성공하면 JjhKiosk.Standby(홀/테이크아웃선택)화면으로 넘어갑니다.

   
3. JjhKiosk.MainWindow : 메인 윈도우입니다. 내용에는 Region 하나밖에없습니다.

   Prism은 Region영역을 설정하여 여러 View를 불러와 Region에 붙일 수 있습니다.

   
4. JjhKiosk.Menu : JjhKiosk.Standby화면에서 홀이나 포장을 선택 시 넘어가는 화면입니다.

   4개의 Region으로 구성되어있으며, 최상단에 배너, 아래에 메뉴 카테고리, 그아래에 음식 메뉴 선택,

   그리고 음식메뉴를 선택하면 나타나는 옵션 선택 팝업화면으로 되어있습니다.

   
5. JjhKiosk.MenuCategory : JjhKiosk.Menu에서 메뉴의 카테고리(커피, 디저트, 차 등등)의 리스트를 DB에서 불러내어 나타냅니다.
  
   카테고리를 선택하면 Prism의 기능으로 MenuList를 변경하도록 JjhKiosk.MenuList프로젝트에 이벤트가 발생합니다.

   
6. JjhKiosk.MenuList : JjhKiosk.MenuCategory에서 선택한 메뉴에 따라 DB에서 카테고리에 해당하는 모든 메뉴를 불러와 리스트에 이미지와 함께 나타냅니다.

   메뉴를 클릭하면 JjhKiosk.Menu화면에서 팝업을 띄워 옵션선택 화면을 볼 수 있게 합니다.

   
7. JjhKiosk.Resource : 프로젝트내에서 사용하는 모든 이미지 리소스를 저장하고있습니다.

   
8. JjhKiosk.Standby : 로그인 이후 홀/포장 선택을 요구하는 화면입니다.

   
9. JjhKiosk.SubMenu : 메뉴리스트에서 메뉴를 선택한 후 나타나는 팝업화면의 디자인을 담당합니다.

    
10. JjhKiosk.Support : 프로젝트에서 사용하는 CustomControl의 모든 디자인과 기능들, 그리고 이벤트와 컨버터,

    인터페이스, 모델 등의 필수요소들을 종합하여 관리하는 프로젝트입니다.
    
11. JjhKiosk.Title : 메뉴 화면 최상단의 움직이는 배너 디자인을 담당하는 프로젝트입니다.


### Utility

1. PasswordHashGenerator : 비밀번호를 해쉬변환하기위한 유틸리티 프로그램입니다.

