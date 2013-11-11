<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="privacyandpolicy.aspx.cs" Inherits="ALEREIMPACT.privacyandpolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../CSS/Privacycss/privacy.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="../css/newstyle.css" type="text/css" />
    <link href="../CSS/Privacycss/mission.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Privacycss/style.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
        .footer {
    background: url("../image/footer_img.png") repeat scroll 0 0 transparent;
    float: left;
    height: 586px;
    margin-top: 1px;
    width: 100%;
    z-index: -99;
}
.side_section_mission{ float:right; text-align:left;}
.copy_right_left {
    color: #333333;
    float: left;
    font-family: Arial,Helvetica,sans-serif;
    font-size: 12px;
    font-weight: bold;
    margin-bottom: 5px;
    margin-left: 5%;
}
.copy_right_rgt {
    color: #333333;
    float: right;
    font-family: Arial,Helvetica,sans-serif;
    font-size: 12px;
    font-weight: bold;
	margin-right:5%;
		width:50%;
	
}
.copy_right_rgt a{ float:right; color:#333333; text-decoration:none;}
.copyrgts {
    background: none repeat scroll 0 0 #EEEEEE;
    border-top: 1px solid #CFCFCF;
    clear: both;
    float: left;
    padding-bottom: 10px;
    padding-top: 10px;
    width: 100%;
}	
</style>
</head>
<body>
    <form id="form1" runat="server">
   <div class="main_btm_miss1" style="margin: 0 auto; overflow: hidden; width: 980px;">
  <div class="cont_miss1">
    <div class="main_cont_miss">
    <div class="top_header">
    <div class="login_logo">
                <asp:ImageButton ID="imgbtmLogo" runat="server" ImageUrl="~/images/imagesNew/vitality_welcomw.png"
                       OnClick="ImgRedirectTo_Click"    />
                </div>
                </div>
     <div class="top_his_miss" style="height: 3px; margin-top: 0 !important; padding-left: 11px !important;
                    padding-top: 22px; width: 964px !important;">
                    
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; font-weight: bold; margin-top: -15px !important;
                            ">Privacy Policy / Data Protection</span>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
       <div style="height: 962px; overflow-x: hidden; overflow-y: scroll; width: 974px;">
      <div class="privacy-contant">
        <div class="privacy-tittle">Introduction</div>
        <div class="privacy-contant-img"><img src="../images/ALERE-VITALITY-policies.png" /></div>
        <p><font color="#000000"; style=" font-family: arial;">
        Our Vitality (accessible via alerevitality.com) takes your privacy and the security of your personal information seriously. We feel that the only way to build a relationship with our users strong enough to become a trusted partner in their health journey is to start with the strictest of standards with regard to sharing your personal information. By default, all your personal information except for your name is hidden from all other users. In your personal settings you can independently elect to show each item of personal information, such as your email address, your weight, or your activity to either your connections in Our Vitality or to all users of Our Vitality. 
        <br />
       <br />
        At Our Vitality, we strive to provide you with an intelligent tool that doesn’t just give you generic health information, but learns about you and your needs and caters information to suit your personality and health goals. As a result, Our Vitality will need to collect information about your health, fitness, preferences and usage of Our Vitality.  Our Vitality will also collect anonymous usage and statistical information about its users in bulk.  All of this information is strictly confidential and protected securely to the standards of any other health-based digital entity.  We will not use this information for any purpose except improving the performance and intelligence of Our Vitality without your explicit consent. We will not share your information with or sell it to a third-party without your explicit consent.
        <br /><br />
        Our Vitality collects information about you from other sites that you choose to connect with your account. One example of this is a connection with FitBit in order to collect information on your activity. Our Vitality has no control over these external sites and we advise you to carefully review their privacy policies as well. We will not share your information with these sites without your explicit consent.
        <br />
        <br />
        
        Your feedback is critical to our continued improvement of Our Vitality. If you ever feel that we could be doing a better job of being a partner in your health journey or have recommendations for making the management of your data easier, please do not hesitate to contact us anytime.
        <br />
        <br />
       Alere, Inc. and its affiliates (collectively, "Alere," "we" or “us”) are committed to respecting the privacy of users of Alere’s website located at alerevitality.com (the “Site”) and Alere’sOur Vitality mobile application (the “Application”) and the services available through the Site and the Application (the “Services”).  Alere created this privacy policy (this “Policy”) to explain what information Alere collects from users of the Services and how it is used. You should read and familiarize yourself with this Policy and with our Terms of Use Agreement (the "Agreement"). Capitalized terms used and not defined in this Policy have the meanings given to them in the Agreement.  BY USING THE SERVICES, SITE OR APPLICATION, YOU AGREE TO ABIDE BY THE TERMS OF THE AGREEMENT AND CONSENT TO THE COLLECTION AND USE OF CERTAIN INFORMATION ABOUT YOU AS SPECIFIED IN THIS POLICY. IF YOU DO NOT AGREE TO THE TERMS AND CONDITIONS OF THIS POLICY AND THE AGREEMENT, YOU MAY NOT USE THE SERVICES, SITE AND APPLICATION.</font></p>
    
      <br />
      <br />
      
       <div class="privacy-tittle">What Information We Collect and How We Use It</div>
        <p><font color="#000000"; style=" font-family: arial;">
        We want you to understand the kinds of information we collect from you and what we do with this information.
            <br />
            <br />
            <label style=" font-family: arial;
    font-size: 14px;">Personal and Health Information</label>
            <br />
            <br />
            We require you to register, acknowledge receipt of this Policy, and agree to the Agreement to use the Services. You may not register for an account on behalf of anyone other than yourself or a group or entity for which you are authorized to do so. To help us tailor certain aspects of the Services to your needs and interests, in order to respond to you and to improve the functionality of the Services, we will ask you to provide some personal information when you complete the registration form (including name, email address, height and weight). In addition, you will be asked to supply personal information, including personal health information, when you enroll in personalized tools and trackers available as part of the Services. If you opt to purchase any goods or services through the Site or Application, we will collect personal financial information, such as credit card number or other financial account information, as necessary to fulfill your order.  We do not collect personal information unless you voluntarily provide it. 
When you are requested to register or enroll to access certain Services but elect not to do so, you may not have access to all of the Services or, if you do, some of the Services may not be optimized for your use. We recognize the importance of protecting your personal information, including your personal health information. Please refer to the "Security" section of this Policy for additional information. Notwithstanding the foregoing, in providing informationthrough the Services, you should not include any genetic information, including any family medical history or any information related to genetic testing, genetic services, genetic counseling, or genetic diseases for which you believe you may be at risk.
<br /><br />
You can invite your friends to join the Vitality community. If you invite a friend to join, we may store your friend’s contact information long enough to authenticate the request. If at any time you provide a third party’s personal information to us, you warrant that you have permission to do so, and you agree to indemnify, defend, and hold us harmless from and against any claim, liability, cost and expense arising in connection with your provision of that information.  
<br />
<br />
<label style="font-size:14px; font-family:Arial;">Demographic Information</label>
<br />
<br />
We may also collect demographic information from you, such as age, gender, and areas of interest for purposes of giving us operational and marketing data about our online visitors’ usage for our business purposes and to improve our Services, the Site and the Application.
<br />
<br />
<label style="font-size:14px; font-family:Arial;">Traffic Data</label>
<br />
<br />
Anonymous traffic data about visitors using the Services, whether through the Site or Application,may be collected using usage analytics tools. Such traffic data may include IP address, MAC (Media Access Control) address or other unique device identifier of the device used to access the Services, device type used to access the Services and its capabilities, operating system version, browser type and its capabilities, number of visitors to the Site, length of visits to the Site and click path taken, lookup information and time spent on certain Services, all of which can help us analyze, market and improve the Services, Site and Application. Analytics tools may also collect other information that may be publicly available in connection with a device identifier such as general location of the user. Alere uses such traffic data and other public to understand usage patterns and to improve the Services, Site and Application.
<br />
<br />
<label style="font-size:14px; font-family:Arial;">Location Services</label>
<br />
<br />
Some of the Services may also request your location from time to time in order to provide more customized information relevant to your general geographic area. You can opt not to provide your location information at anytime by selecting “no” when prompted or through the settings of the device you use to access the Services. 
<br />
<br />
<label style="font-size:14px; font-family:Arial;">Do Not Track Requests</label>
<br />
<br />
Unless your browser settings are configured to make your online activities and publicly available information about your online activities (such as traffic data described above, including unique device identifier of the device used to access the Services, device type used to access the Services and its capabilities, operating system version, browser type and its capabilities, length of visits to the Site and click path taken, lookup information and time spent on certain Services) invisible to usages analytics tools, we do not presently have the technological capability to omit you from usage analytics to the extent your browser only sends us a “do not track” message and does not otherwise screen you from tracking without any action on our part. 
<br />
<br />
<label style="font-size:14px; font-family:Arial;">Changing Your Personal Information</label>
<br />
<br />
Do not track requests from a browser do not affect personal information that you previously submitted to us, but you may change or delete your personal information by updating your registered user account information. If you provided personal information within a particular tool or tracker, you may also be able to change or delete that information by visiting the specific tool or tracker and submitting the appropriate changes. Alere will maintain your personal information for the period of time required or permitted by applicable law and in accordance with our record retention policies, for so long as necessary to meet the purpose for which such information was collected.
<br />
<br />
<label style="font-size:14px; font-family:Arial;">We Will Use Your Personal Information to Contact You</label>
<br />
<br />
We will use your personal information to contact you, if necessary, or, if you choose to receive email from us, to send you newsletters and other communications to inform you about special offers or events that might interest you. To stop receiving email communications, please see “Email Communications from Alere” below.In the event the email address you provide to us is your work email account or is otherwise provided by your employer, or you access your personal email address from a device issued by your employer, you expressly acknowledge that your employer may have access to any emails sent to that address in accordance with your employer’s applicable computer use policies.Emails that we send to you may contain health and wellness information that we think will be useful to you based on the information you provide us through the Site or Application, as well as disclose your own personal health information, which you may not desire your employer to have access to.
<br />
<br />
<label style="font-size:14px; font-family:Arial;">Information Sharing</label>
<br />
<br />
Alere limits sharing of information it collects to its Service Providers with a need to know such information. Alere may also disclose such information: (i) to subsidiary and parent companies and other affiliated legal entities with whom Alere, Inc. is under common corporate control, (ii) in the event of a change of ownership or transfer of Alere assets, (iii) in the event of a bankruptcy, where required to do so by law, (iv) to prevent a crime, conduct investigations of possible breaches of law, or bring legal actions against someone who may be violating the Agreement, (v) to protect the safety of the Services or any users, or (vi) as required by law or in response to a government or court order. For the purposes of this Policy, the term "Service Provider" means an Alere agent, representative, contractor, or other provider of a service or product with whom Alere has an agreement pursuant to which the Service Provider supports the operation of Alere. By initiating any activity or transaction through the Services that uses financial information, you consent to providing your financial information to our Service Providers processing the transaction to the extent required to provide the payment services to you. Any Alere parent, subsidiary and/or affiliated legal entity that receives your personal information from the Services will treat it in accordance with the terms of this Privacy Policy.  
<br />
<br />
To the extent that the Services are made available to you through a health plan, we may share information we collect with individuals and entities involved in your health plan and/or health care in accordance with applicable laws, or at your request. Generally, uses and disclosures of your personal health information outside of treatment, payment and other operational needs are not permitted under applicable law or health plan contracts without your prior consent. To the extent that the Services are made available to you through an employer or another third party, we may share certain aggregate user information on an anonymous basis, such as reporting to the employer the number if its employees using the Services or the frequency of their collective use. 
<br /><br />
From time to time, Alere may share traffic data about usage of the Site, as described above, in the aggregate, such as by publishing a report on trends regarding usage of the Site and/or Application. Alere may also share such information with its Service Providers or marketing partners.
<br /><br />
Alere does not knowingly permit third parties, except for its subsidiary and parent companies and other affiliated legal entities with whom Alere, Inc. is under common corporate control, Service Providers operating usage analytics tools at the request of Alere, or such third parties as authorized by law, i.e., law enforcement, to collect your personal information from, or track you(i.e., to obtain traffic data through usage analytics tools) through, the Site or Application, but your personal information may nonetheless be visible to third parties through the Services to the extent you make it public, for example by posting User Content to Public Areas. Your screen name, which may identify you, may also be visible to third parties in Public Areas. Please see below in “Posting User Content to Public Areas” or refer to the Agreement for more information about the use of Public Areas. 
<br />
<br />

        </font>
        </p>
          </div>
      <div class="privacy-contant-sub_part">
        <div class="privacy-post-description-left">
       
            <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/4.png" /></div>
            <div class="privacy-post-tittle">Email Communications from Other Users</div>
            <div class="privacy-post-description">By finding and connecting with your friends and other users of the Services, you may receive electronic communications, including email and personal messages from other users of the Services. You can manage the messages you receive from other users by changing the message preferences in your account.  </div>
          </div>
           <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/4.png" /></div>
            <div class="privacy-post-tittle">Email Communications from Alere</div>
            <div class="privacy-post-description">If you agree to receive them, we may send you commercial email communications regarding products, services, promotions, or other information. We may also learn of third parties who provide products or services that we believe may be of interest to you. If so, and only if you have agreed to receive commercial email from us, we may notify you 
            on such third parties' behalf.  You always have the right to opt-out of having your personal information used for commercial purposes:  <br />
            <br />
            •  By following unsubscribe directions stated in the footer of email communications.
            <br />
             <br />
            •  By contacting Customer Care through the Services.
<br />
<br />
           •  By cancelling your registration to use the Services.  
<br />
<br />
Please note that your election not to receive commercial material will not preclude us from corresponding with you, by e-mail or otherwise, regarding your existing or past business relationships with us (e.g., any use of our Services, or responses to requests for information you pose to us either through use of the Services or by other means), and will not preclude us from accessing and viewing your personal information in the course of maintaining and improving our Services, the Site and the Application. 
              </div>
          </div>
           <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/14.png" /></div>
            <div class="privacy-post-tittle">Your Responsibility</div>
            <div class="privacy-post-description">Although we use reasonable efforts to protect your privacy on the Site as described in this Policy, you should keep in mind that if you disclose personal information in Public Areas or give others access to your computer, mobile device or password, your privacy may be limited and your personal information, including personal health information, may be accessible to others. You can help guard against this by never disclosing your password, not giving anyone else access to your computer or mobile device, and by ensuring that information you disclose online is transmitted securely.  </div>
          </div>
          
           <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/8.png" /></div>
            <div class="privacy-post-tittle">Use of Cookies</div>
            <div class="privacy-post-description">Alere may use cookies to customize your experience with the Services. Your browser is probably set to accept coo-kies. However, if you would prefer not to receive cookies, you can change your browser settings to refuse them. If you choose to have your browser refuse cookies, it is possible that some Services  will not function properly when you view or access them, and you may have to re-enter personal information every time you access the Services to participate in certain Services.  </div>
          </div>
           <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/8.png" /></div>
            <div class="privacy-post-tittle">International Users</div>
            <div class="privacy-post-description"> Alere is headquartered in the United States. If you are located outside of the United States, be advised that any information you provide to us will be transferred to and stored in the United States and that, by submitting information to us, you explicitly authorize its transfer and storage within the United States. We will protect the privacy and security of personal information according to this Privacy Policy regardless of where it is processed or stored.  </div>
          </div>
           
           <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/10.png" /></div>
            <div class="privacy-post-tittle">Third Party Web Sites</div>
            <div class="privacy-post-description">Alere cannot control the privacy policies of web sites you may access through this Site that are not owned or operated by us. In order to determine the privacy practices of those third party web sites, you must refer to the privacy policies, if any, associated with those web sites. You should carefully review such Privacy Policies and Terms of Use before using such third party web sites or disclosing any personal information on those web sites.

 </div></div>
        </div>
        <div class="privacy-post-description-mid">
         <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/3.png" /></div>
            <div class="privacy-post-tittle">Security</div>
            <div class="privacy-post-description">We have security measures in place to protect against the loss, misuse, and alteration of information under our control. We use TLS (Transport Layer Security) to encrypt and password protect all information transmitted to or from the secure areas of the Services. We have implemented and maintain administrative, physical and technological safeguards that we believe reasonably and appropriately protect the confidentiality, integrity and availability of all personal information, including protected health information, submitted by you through the Services; however, Alere cannot and does not represent that the Site or Application are hack-proof or 100% secure.  </div>
          </div>
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/5.png" /></div>
            <div class="privacy-post-tittle">Notice</div>
            <div class="privacy-post-description"> At the time that Alere collects Personal Information from you for any of the purposes identified above, we will inform you of the purpose for which the Personal Information is being collected and used, and how to contact Alere with any questions or complaints, or to update your Personal Information.  Alere will not disclose Personal Information to third parties except in accordance with this Policy and as disclosed at the time of the collection of the Information. </div>
          </div>
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/6.png" /></div>
            <div class="privacy-post-tittle">Purposes of Collection of Personal Information</div>
            <div class="privacy-post-description"> Alere's collection and use of Personal Information in the employment context is essential in connection with the conduct of Alere's human resources and business functions. Examples of the purposes for which Alere collects and uses Personal Information include, without limitation, recruitment, payroll, and personnel management, such as compensation, promotion, evaluation, benefit administration and succession planning, and designing and implementing employment-related education and training programs, and maintaining facility and employee security, health, and safety.  Unless required by applicable law, Alere does not request or record Sensitive Personal Information. <br />
              <br />
              To the extent practical and appropriate, Alere collects Personal Information directly from the Identifiable Person. In those cases where Alere collects Personal Information from other persons, it takes measures to respect the privacy preferences of the Identifiable Person. Examples of when Alere may seek information from others include, without limitation, evaluating employees, recruiting, benefit administration and succession planning. <br />
              <br />
              Alere also collects Personal Information from contacts made through its website.  When Personal Information is supplied at an Alere website, we will use it for the express purpose for which it was collected, or for other purposes disclosed at the time when the Personal Information is supplied.  See "Information Collected on our Websites" below for additional information. </div>
          </div>
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/7.png" /></div>
            <div class="privacy-post-tittle">Choice</div>
            <div class="privacy-post-description"> Alere will offer you the opportunity to choose whether your Personal Information is to be (a) disclosed to a third party or (b) used for a purpose other than that for which the Personal Information was originally collected or subsequently authorized by you.<br />
              <br />
              Alere will not disclose Sensitive Personal Information to a third party or use it for any purpose other than that for which it was originally collected or subsequently authorized by you, except as required by law, court order, or subpoena. </div>
          </div>
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/12.png" /></div>
            <div class="privacy-post-tittle">Changes to this Policy</div>
            <div class="privacy-post-description">Alere reserves the right to make changes to this Policy at any time by posting our new policy on the Site. Modifications to the Policy shall be effective when they are posted on this Site, in which case posting shall constitute notice to you. To the extent we make material changes to the Policy, we will list those sections to which the material changes were made below. Your continued use of the Site following the posting of any such modifications on the Site constitutes your acceptance and agreement to be bound by such modifications. We encourage you to check the Site regularly to see if we have made any modifications to this Policy. </div>
          </div>
          

          
        </div>
        <div class="privacy-post-description-right">
         <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/10.png" /></div>
            <div class="privacy-post-tittle">Transfer to Third Parties</div>
            <div class="privacy-post-description">If you create an account using your login/ID from a third-party platform, like Facebook®, Alere will use your login/ID to access and collect information as permitted by your privacy settings on that third-party platform to create your account with Alere and connect you with your friends. </div>
          </div>
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/2.png" /></div>
            <div class="privacy-post-tittle">Your California Privacy Rights</div>
            <div class="privacy-post-description">Effective January 1, 2005, California Civil Code Section 1798.83 (known as the “Shine the Light” law) provides that, if an individual who is a California resident has provided his/her personal information to a business in connection with a business relationship that is primarily for personal, family, or household purposes, and if that business has within the immediately preceding calendar year disclosed such individual’s personal information to a third party and knows or should have known that such third party used the information for its own direct marketing purposes, then that business is obligated to disclose in writing to such individual upon request, what personal information was shared and with whom the information was shared. A business may comply with this law by: (1) having EITHER a published privacy policy of not sharing a customer’s personal information for third-party direct marketing use unless the customer has first affirmatively opted in to such sharing OR a published privacy policy of not sharing a customer’s personal information for third-party direct marketing use if the customer has opted out to prevent his/her personal information from being shared for third-party direct marketing use; AND (2) notifying the customer of his/her right to opt out and providing a cost-free means for the customer to exercise that right.
            <br />
            <br />
            California residents may request an information-sharing disclosure from us by emailing your request to <label style="text-decoration:underline; color:Blue;">Corpfeedback@alere.com </label> or writing to us at:
            <br />
            <br />
             <label style="text-decoration:underline; color:Blue;">Alere, Inc. </label>
             <br />
            <br />
             <label style="text-decoration:underline; color:Blue;">Attention: Alere Our Vitality</label>
             <br />
            <br />
             <label style="text-decoration:underline; color:Blue;">Director of Global Digital Innovation</label>
             <br />
            <br />
             <label style="text-decoration:underline; color:Blue;">9975 Summers Ridge Road</label>
             <br />
            <br />
             <label style="text-decoration:underline; color:Blue;">San Diego, CA 92121</label>
             <br />
             <br />
             Please note that, under the law, we are not required to respond to your request more than once in a calendar year, nor are we required to respond to any requests that are not sent to the above-designated email or mailing address.
            </div>
          </div>
        
           <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/10.png" /></div>
            <div class="privacy-post-tittle">Posting User Content to Public Areas</div>
            <div class="privacy-post-description">You acknowledge that Public Areas (as defined in the Agreement), and features contained therein, are for public and not private communications. You further acknowledge that anything you upload, submit, post, transmit, communicate, share or exchange by means of any Public Area may be viewed on the Internet by the general public, and therefore, you have no expectation of privacy with regard to any such submission or posting. Please see the Agreement for more information about the use of such Public Areas, and the posting of User Content to such Public Areas.</div>
          </div>
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/11.png" /></div>
            <div class="privacy-post-tittle">Contact Information </div>
            <div class="privacy-post-description">If you would like to receive this Policy in another language or have any questions about this Policy or your dealings with our Site or Application, please feel free to contact us by email to 
            <label style="color:Blue; text-decoration:underline;"> Corpfeedback@alere.com </label>, allowing up to two business days for a customer care representative to respond to your message.</div>
          </div>
         
          <div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/13.png" /></div>
            <div class="privacy-post-tittle">Your Use of the Services, Site and Application is Subject to this Policy</div>
            <div class="privacy-post-description"> You will be prompted to click “I Agree” to evidence your consent and agreement to abide by the terms of this Policy and the Agreement. Your clicking "I Agree" is the equivalent of your signature and evidences your express written consent and intention to abide by the terms of this Policy and the Agreement. However, please note that in the event that you have gained access to the Services, Site or Application without affirmatively having had to click“I Agree,” your use of the Services, Site or Application means you agree to this Policy and the Agreement, and if you do not, you should immediately discontinue use of the Services, Site and Application.</div>
          </div>
          <%--<div class="privacy-post">
            <div class="privacy-post-tittle-img"><img src="../images/14.png" /></div>
            <div class="privacy-post-tittle">Enforcement</div>
            <div class="privacy-post-description"> Alere will conduct periodic internal audits to our ongoing adherence to this Policy, and will promptly seek to remedy any instances of noncompliance brought to its attention. </div>
          </div>--%>
        </div>
      </div>
      </div>
    </div>
  </div>
</div>

<div id="dvFooter" runat="server">
        <div class="footer_miss">
        </div>
    </div>

    <div class="copyrgts">
 
         <div class="copy_right_left">
            © 2011 Vitality
        </div>
      <div class="copy_right_rgt">
       <asp:LinkButton ID="lnkSupport" runat ="server" OnClick ="lnkSupport_Click">| Support</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lnkprivacynPolicy" runat ="server" OnClick ="lnkprivacynPolicy_Click">| Privacy Policy</asp:LinkButton>
        &nbsp;
           <asp:LinkButton ID="lnkTermsnConditions" runat ="server" OnClick="lnkTermsnConditions_Click" >Terms & Conditions</asp:LinkButton>
          
        </div>
        </div>
    </form>
</body>
</html>

