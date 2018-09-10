Public Class Form1
    Dim Winhttp As New WinHttp.WinHttpRequest
    Dim Url As String = "http://www.seoultech.ac.kr/service/info/notice/"

    '개발자 정보
    '서울과학기술대학교 컴퓨터공학과 ITS
    'Blog : http://its319.tistory.com/
    'E-mail : ehn1225@seoultech.ac.kr
    '제작년일 : 2018-09-05

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Select Case ComboBox1.SelectedIndex
            Case 0
                Url = "http://www.seoultech.ac.kr/service/info/notice/"
            Case 1
                Url = "http://www.seoultech.ac.kr/service/info/matters/"
            Case 2
                Url = "http://www.seoultech.ac.kr/service/info/janghak/"
            Case 3  '공과대학
                Url = "http://engineer.seoultech.ac.kr/community/notice/"
            Case 4
                Url = "http://msd.seoultech.ac.kr/information/bulletin/"
            Case 5
                Url = "http://mae.seoultech.ac.kr/bachelor/bulletin/"
            Case 6
                Url = "http://safety.seoultech.ac.kr/b_information/notic/"
            Case 7
                Url = "http://mse.seoultech.ac.kr/b_intro/notice/"
            Case 8
                Url = "http://inarc.seoultech.ac.kr/ba/news/"
            Case 9
                Url = "http://mee.seoultech.ac.kr/info/news/"
            Case 10
                Url = "http://fm.seoultech.ac.kr/info/news/"
            Case 11
                Url = "http://civil.seoultech.ac.kr/haksainfor/bulletin/"
            Case 12
                Url = "http://ebse.seoultech.ac.kr/info/notice/"
            Case 13
                Url = "http://architecture.seoultech.ac.kr/bachelor_of_information/notice/"
            Case 14
                Url = "http://archidesign.seoultech.ac.kr/bachelor_information/notice/"
            Case 15  '정통대
                Url = "http://ice.seoultech.ac.kr/community/notice/bulletin/"
            Case 16
                Url = "http://eie.seoultech.ac.kr/majornotice/notice/"
            Case 17
                Url = "http://eeme.seoultech.ac.kr/bachelor_info/notice/"
            Case 18  '컴퓨터공학과
                Url = "http://computer.seoultech.ac.kr/info_plaza/notic/"
            Case 19  '에바대
                Url = "http://nature.seoultech.ac.kr/community/notic/"
            Case 20
                Url = "http://che.seoultech.ac.kr/engineering_certification/board/"
            Case 21
                Url = "http://enviro.seoultech.ac.kr/information/notice/"
            Case 22
                Url = "http://food.seoultech.ac.kr/bachelor/notice/"
            Case 23
                Url = "http://fchem.seoultech.ac.kr/bachelor_of_information_/notice_/"
            Case 24
                Url = "http://sports.seoultech.ac.kr/b_information/notic/"
            Case 25
                Url = "http://optometry.seoultech.ac.kr/bachelor_of_information/notice/"
            Case 26  '조형대학
                Url = "http://and.seoultech.ac.kr/advertisements/notice/"
            Case 27
                Url = "http://design.seoultech.ac.kr/square/bulletin/"
            Case 28
                Url = ""
                Process.Start("https://ceramic.seoultech.ac.kr/html/board/list.php?board=11")
            Case 29
                Url = "http://metalartdesign.seoultech.ac.kr/b_information/notic/"
            Case 30
                Url = "http://fineart.seoultech.ac.kr/community/notice/"
            Case 31  '인사대
                Url = "http://human.seoultech.ac.kr/community/notice/"
            Case 32
                Url = "http://eng.seoultech.ac.kr/information_plaza/notice/"
            Case 33
                Url = "http://pa.seoultech.ac.kr/admini/notice/"
            Case 34
                Url = "http://writing-creative.seoultech.ac.kr/bachelor_of_information_/notice_/"
            Case 35
                Url = "http://liberal.seoultech.ac.kr/community/notic/"
            Case 36  '기술경영융합
                Url = "http://sgc.seoultech.ac.kr/open/notice/"
            Case 37
                Url = "http://iise.seoultech.ac.kr/notice/faculty_announcements_/"
            Case 38
                Url = "http://msde.seoultech.ac.kr/academics_/qna/"
            Case 39
                Url = "http://itm.seoultech.ac.kr/bachelor_of_information/notice/"
            Case 40
                Url = "http://biz.seoultech.ac.kr/info_plaza/notic/"
            Case 41
                Url = "http://gtm.seoultech.ac.kr/info_plaza/gtm_info/"
            Case 42  '부속시설
                Url = ""
                Process.Start("http://www.seoultech.ac.kr/life/attatched/press/")
            Case 43
                Url = "http://m-disciplinary.seoultech.ac.kr/community/notice/"
            Case 44
                Url = "http://mc.seoultech.ac.kr/community/notice/"
            Case 45
                Url = "http://sssf.seoultech.ac.kr/community/notice/"
            Case 46
                Url = "http://icee.seoultech.ac.kr/bbs/notice/"
            Case 47
                Url = ""
                Process.Start("http://global.seoultech.ac.kr/")
        End Select

        If Not Url = "" Then
            Roadpage(ComboBox1.SelectedIndex)
        End If

    End Sub

    Private Sub Roadpage(SelectedIndex As Integer)
        ListView1.Items.Clear()

        Dim temp As String
        Dim countnotice As Integer

        Winhttp.Open("GET", Url)
        Winhttp.Send()
        countnotice = UBound(Split(Winhttp.ResponseText, "<tr class=""body_tr"">")) '공지사항의 개수를 받아옴.]
        If SelectedIndex < 3 And Not countnotice = 0 Then
            For i = 1 To countnotice
                temp = Split(Split(Winhttp.ResponseText, "<tr class=""body_tr"">")(i), "</tr>")(0) 'source에 공지사항을 받아옴.
                ListView1.Items.Add(i)
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, ">")(4 + UBound(Split(temp, "ico_notice_ko.gif"))), "<")(0))
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, "<td style=""text-align: center;"">")(3), "</td>")(0)) '게시일자
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, "<td style=""text-align: center;"">")(4), "</td>")(0)) '게시자
                ListView1.Items(i - 1).SubItems.Add(Url)
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, "<a href='")(1), "'>")(0))
            Next
        ElseIf SelectedIndex >= 3 And Not countnotice = 0 Then
            For i = 1 To countnotice
                temp = Split(Split(Winhttp.ResponseText, "<tr class=""body_tr"">")(i), "</tr>")(0) 'temp에 공지사항을 받아옴.
                ListView1.Items.Add(i)
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, ">")(5 + UBound(Split(temp, "ico_notice_ko.gif"))), "<")(0))
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, "<td class=""body_col_regdate"" align=""center"">")(1), "</td>")(0))
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, "<td class=""body_col_user"" align=""center"">")(2), "</td>")(0))
                ListView1.Items(i - 1).SubItems.Add(Url)
                ListView1.Items(i - 1).SubItems.Add(Split(Split(temp, "<a href='")(1), "'>")(0))
            Next
        Else
            MsgBox("공지사항이 없습니다.")
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://www.seoultech.ac.kr/index.jsp")

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("http://its319.tistory.com/")
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        MessageBox.Show("개발 : ITS" & Chr(13) & "E-Mail : ehn1225@seoultech.ac.kr" & Chr(13) & "개발 및 배포일자 : 2018-09-05", "개발자정보", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Process.Start(ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text & ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text)

    End Sub
End Class
