<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages.Master" AutoEventWireup="true" CodeBehind="DirectorMessage.aspx.cs" Inherits="e_Portfolio_System.DirectorMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 454px;
        }
        .auto-style2 {
            text-align: center;
            font-style: italic;
            font-weight: bold;
            font-size: x-large;
            color: #800080;
        }
        .auto-style3 {
            width: 454px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style2" colspan="2">Director&#39;s Message</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/male2.jpg" Width="250px" />
            </td>
            <td>
                <br />
                <br />
                Dear Students,
                <br />
                Welcome to a new semester with the School of InfoComm Technology (ICT)! This will be an exciting semester for you as you will be the first batch of ICTians to use our new Smart Learning Spaces called The BYTE™. The BYTE™ is part of Ngee Ann Polytechnic’s Smart Campus initiative and its aims are to provide an immersive, technology-enabled learning environment that equips our students with the right skillsets and mindsets to support the Smart Nation programme. The BYTE™ consists of Technology Enhanced Classrooms, a Security Operations Centre and The Whitehat Zone for ethical hacking and cyber-security training, an e-Garage® (Digital Maker’s space) for creating digital products, and areas for industry collaboration such as the SAP Next-Gen Lab and FinTech &amp; Analytics Lab. You will also be the first batch of students who will benefit from a revision in our IT curriculum. This revision will see the introduction of a new module, Portfolio 1, for this semester. This module provides students 
                with the opportunity to apply the knowledge and skills gained from the various modules in the course to date, and develop an IT artifact suitable for your personal portfolio. Students may choose to undertake a real-life IT project, a competition-based project or a research and development project. Supporting Ngee Ann Polytechnic’s commitment to provide all students with overseas exposure, our Year 2 students spent 2-3 weeks during their September vacation overseas as part of our overseas immersion programme (OIP). 48 ICTians were in Beijing where they gained insights into China’s social enterprise during their visit to Beijing Sun Village Orphanage and developed a deeper appreciation of the country’s culture through industry visits and networking with the local students. 23 A3DA students were in the United States where they attended master classes and were hosted by industry leaders like Google, Yahoo, Autodesk and Disney Animations during their visits to the various cities. We are 
                also proud of our Information Security &amp; Forensics diploma students, Devesh Logendran and Wan Si Zheng who secured 3rd position in the recent Singapore Cyber Conquest. They were competing against 26 other teams including students from the National University of Singapore. They showed their resilience and came out stronger from the experience. For more highlights of the happenings around ICT, please read below. We look forward to journeying with you in the coming semester.
                <br />
                <br />
                Yours sincerely,
                <br />
                Ng Poh Oon
                <br />
                Director School of InfoComm Technology</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
