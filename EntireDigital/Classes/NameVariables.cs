using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntireDigital
{
    public static class NameVariables
    {
        public const string URL = "https://creator-stage.contents.com/";
        public const string URL_YOP = "http://www.yopmail.com/ru/";

        public const string EMAIL_ADMIN = "celladecummo-1094@yopmail.com";
        public const string PASSWORD_ADMIN = "Test123!";

        public const string EMAIL_EDITOR = "weddehyttatt-6265@yopmail.com";
        public const string PASSWORD_EDITOR = "Test123!";

        public const string DEFAULT_TITLE = "EDP - News";
        public const string DEFAULT_TITLE_EDITOR = "EDP - Summary";

        public const string USERS = "Users";

        public const string FRAME = "ifmail";




    }

    public static class NameForCreateArticle
    {
        public const string TITLE = "Lorem ipsum dolor sit amet";
        public const string CATEGORY_NERA = "nera";
        public const string CATEGORY_ECONOMIA = "economia";
        public const string CATEGORY_CRONACA = "Cronaca";
        public const string CATEGORY_POLITICA = "politica";
        public const string IFRAME_TEXT = "Lorem ipsum dolor sit amet";
        public const string IFRAME = "summernote-content_ifr";

        public const string TITLE_H1 = "Lorem ipsum dolor sit amet";
        public const string HOME_TITLE = "Lorem ipsum dolor sit amet";
        public const string ALT_TITLE = "Lorem ipsum dolor sit amet";
        public const string SUMMARY = "Lorem ipsum dolor sit amet";

        public const string META_TITLE = "Lorem ipsum dolor sit amet";
        public const string DESCRIPTION_TITLE = "Lorem ipsum dolor sit amet";
        public const string SLUG = "Lorem ipsum dolor sit amet";
        public const string FOCUS_KEY = "Lorem ipsum";

        public const string ER_AFTER_ADD_TAG = "Tag was added!";
        public const string FIRST_TAG = "amazon";
        public const string SECOND_TAG = "coronavirus";

        public const string SOURCE_NAME_ELEM = "facebook";
        public const string SOURCE_URL = "https://facebook.com";
        public const string PUTH_IMAGE = "D:\\ListScreener\\Test Add Image.jpg";
        public const string ER_AFTER_ADD_IMAGE = "Data saved!";

        public const string SCRIPT = "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

        public const int ZERO = 0;

        public const string RED_ESTERI_BLOG_TEST_TEXT = "Red Esteri Blog TEST";
        public const string INVISIBLE_STATUS = "INVISIBLE";
        public const string VISIBLE_STATUS = "VISIBLE";

        public const string ANACONDA_EDITOR = "anaconda anaconda (Ranking: 1)";

        public const string TEXT_EVALUATING = "We're evaluating your Profile!";

    }



    public static class NameForCreateUser
    {
        public const string FIRST_NAME = "TestAuto";
        public const string LAST_NAME = "Editor";
        public const string BIRTH_CITY = "Kharkiv";
        public const string BIRTH_DATE = "10/08/1990";
        public const string CITY = "Kharkiv";
        public const string ADDRESS = "www.Leningrad";
        public const string ZIP_CODE = "1234";
        public const string MOBILE_PHONE = "1234567890";
        public const string PAYPAL_ACCOUNT = "Test QA Paypal Account";
        public const string FISCAL_CODE = "Test QA Fiscal Code";
    }

    public static class NameForCreteGroup
    {
        public const string NAME_GROUP = "Group";
        public const string DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        public const string NAME_ANACONDA = "anaconda anaconda";
        public const string ZERO_USERS = " (0 users)";
        public const string ONE_USER = " (1 users)";
        public const string NO_FOUND_GROUP = "No matching records found";
    }


    public static class NameSections
    {
        public const string NEWS = "News";
        public const string USERS = "Users";
        public const string CONTENTS = "Contents";
        public const string CATEGORIES = "Categories/Tags";
        public const string SUMMARY = "Summary";
        public const string CASH_FLOWS = "Cash Flows";
        public const string USERS_STATS = "Users Stats";
        public const string GROUPS = "Groups";
        public const string STAFF = "Staff";
        public const string FEES = "Fees";
        public const string PAYMENTS = "Payments";

    }



    public static class NameNewsSection
    {
        public const string AUTHOR_SEARCHING = "Author Searching";
        public const string WRITING = "Writing";
        public const string DRAFTS = "Drafts";
        public const string PROOFREADER_SEARCHING = "Proofreader Searching";
        public const string CORRECTING = "Correcting";
        public const string READY_FOR_PUBLICATION = "Ready for Publication";
        public const string PUBLISHED = "Published";
        public const string WAITING_FOR_YOU = "Waiting for You";
        public const string DELIVERED = "Delivered";
    }

    public static class NameUsersSection
    {
        public const string ACTIVE = "Active";
        public const string PENDING = "Pending";
        public const string WAITING_FOR = "Waiting For..";
        public const string REJECTED = "Rejected";
    }

    public static class NameContentsSection
    {
        public const string PENDING = "Pending";
        public const string TO_BE_DELIVERED = "To be delivered";
        public const string DELIVERED = "Delivered";
        public const string ECONOMICS = "Ecomomics";
    }

    public static class NameCategoriesSection
    {
        public const string CATEGORIES = "Categories";
        public const string TAGS = "Tags";
    }
}
