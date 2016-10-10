using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace ebibliotekarz
{
    internal class Scopus : POSTMet
    {
        private List<StructScop> _listscopus;

        public List<StructScop> listscopus
        {
            get { return _listscopus; }
        }

        public void scopus(object objekty)
        {
            //int licznik = 0;  
            var objektyarray = (object[]) objekty;
            string search = objektyarray[0].ToString();
            var datafr = (int) objektyarray[1];
            var datato = (int) objektyarray[2];
            string datasite =
                "numberOfFields=0&src=&clickedLink=&edit=&origin=searchbasic&authorTab=&affiliationTab=&advancedTab=&scint=1&menu=search&tablin=&searchterm1=" +
                search +
                "&field1=TITLE-ABS-KEY&dateType=Publication_Date_Type&yearFrom=Before+1960&yearTo=Present&loadDate=7&documenttype=All&subjects=LFSC&subjects=HLSC&subjects=PHSC&subjects=SOSC&null=";
            string datasite2 =
                "previous=false&next=false&downloadPdf=false&export=false&print=false&email=false&createBibliography=false&addToMyList=false&viewReferences=false&viewCitations=false&citationOverview=false&sot=b&sid=9EBF380E3A81D6E4329F1DD00A9C353D.iqs8TDG0Wy6BURhzD3nFA%3A120&sdt=b&s=TITLE-ABS-KEY%28asd%29&sl=18&sort=plf-f&stem=t&src=s&mltAll=f&sortOrderFlag=f&searchWithinResultsDefault=t&news=&clsYearCount=5&clsAuthnameCount=5&scla=%23+of+results&clsSubareaCount=5&sclsb=%23+of+results&clsDocTypeCount=5&clsSrctitleCount=5&scls=%23+of+results&clsKeyCount=5&sclk=%23+of+results&clsAffilCount=9&clsDocCntryCount=5&sclc=%23+of+results&clsSrctypeCount=6&clsLangCount=5&scll=%23+of+results&displayClusteringCountFlag=f&refinedSearchString=TITLE-ABS-KEY%28asd%29&groupCheckBox=on&oldSelectAllCheckBox=false&selectAllCheckBox=on&exportRadio=on&view=CiteOnly&selectedCitationInformationItemsAll=on&selectedCitationInformationItems=_Authors_&selectedCitationInformationItems=_Title_&selectedCitationInformationItems=_Year_&selectedCitationInformationItems=_EID_&selectedCitationInformationItems=_SourceTitle_&selectedCitationInformationItems=_Volume_Issue_ArtNo_PageStart_PageEnd_PageCount_&selectedCitationInformationItems=_CitedBy_&selectedCitationInformationItems=_DocumentType_Source_&exportTypeSelection=on&emailFormat=on&DOC_DISPLAY_LINK_COUNT=&isAbsExpanded=false&selectedEIDs=2-s2.0-84907652029&selectedEIDs=2-s2.0-84907821858&selectedEIDs=2-s2.0-84907302864&selectedEIDs=2-s2.0-84907457459&selectedEIDs=2-s2.0-84907573432&selectedEIDs=2-s2.0-84907646054&selectedEIDs=2-s2.0-84907602564&selectedEIDs=2-s2.0-84905215830&selectedEIDs=2-s2.0-84907675583&selectedEIDs=2-s2.0-84907637887&selectedEIDs=2-s2.0-84907598648&selectedEIDs=2-s2.0-84907370794&selectedEIDs=2-s2.0-84907279960&selectedEIDs=2-s2.0-84907557961&selectedEIDs=2-s2.0-84906314787&selectedEIDs=2-s2.0-84907514798&selectedEIDs=2-s2.0-84907892340&selectedEIDs=2-s2.0-84904916807&selectedEIDs=2-s2.0-84907899118&selectedEIDs=2-s2.0-84907899178&displayPerPageFlag=f&resultsPerPage=20&endPage=714&currentPage=1&documentJumpToPageDefault=t&count=14272&scount=0&pageselecttotal=0&cc=10&offset=1&nextPageOffset=21&prevPageOffset=&partialQuery=&sortField=RelevanceSortButton&resultsTab=&currentSource=s&oldResultsPerPage=20&clustering=&sortClusterField=&oldScls=&oldScla=&oldSclc=&oldSclsb=&ss=plf-f&ws=r-f&ps=r-f&ref=&clickedLink=export&citeCnt=&mciteCt=&img=&tgt=&nlo=&nlr=&nls=&cs=r-f&contextBox=&origin=resultslist&selectDeselectAllAttempt=clicked&oneClickExport=%7B%22Format%22%3A%22BIB%22%2C%22View%22%3A%22CiteOnly%22%7D&zone=exportDropDown&recordid=&relpos=&pageEIDs=2-s2.0-84907652029%212-s2.0-84907821858%212-s2.0-84907302864%212-s2.0-84907457459%212-s2.0-84907573432%212-s2.0-84907646054%212-s2.0-84907602564%212-s2.0-84905215830%212-s2.0-84907675583%212-s2.0-84907637887%212-s2.0-84907598648%212-s2.0-84907370794%212-s2.0-84907279960%212-s2.0-84907557961%212-s2.0-84906314787%212-s2.0-84907514798%212-s2.0-84907892340%212-s2.0-84904916807%212-s2.0-84907899118%212-s2.0-84907899178&allSourceClusterCategories=Journal+of+Autism+and+Developmental+Disorders%23%23%23Research+in+Autism+Spectrum+Disorders%23%23%23Autism+Research%23%23%23Plos+One%23%23%23Catheterization+and+Cardiovascular+Interventions%23%23%23Research+in+Developmental+Disabilities%23%23%23Autism%23%23%23Journal+of+Child+Psychology+and+Psychiatry+and+Allied+Disciplines%23%23%23Molecular+Autism%23%23%23Kyobu+Geka+the+Japanese+Journal+of+Thoracic+Surgery&allAuthorClusterCategories=55651995300%23%23%237101634220%23%23%239634532200%23%23%237201539036%23%23%237102606691%23%23%237006913774%23%23%236602185665%23%23%237006673362%23%23%2326640178500%23%23%237402594156&allCountryClusterCategories=United+States%23%23%23United+Kingdom%23%23%23China%23%23%23Canada%23%23%23Germany%23%23%23Japan%23%23%23Italy%23%23%23Australia%23%23%23Netherlands%23%23%23France&allYearClusterCategories=2015%23%23%232014%23%23%232013%23%23%232012%23%23%232011%23%23%232010%23%23%232009%23%23%232008%23%23%232007%23%23%232006&allDocTypeClusterCategories=ar%23%23%23cp%23%23%23re%23%23%23ip%23%23%23ch%23%23%23no%23%23%23le%23%23%23sh%23%23%23ed%23%23%23cr&allSubjectClusterCategories=MEDI%23%23%23PSYC%23%23%23NEUR%23%23%23ENGI%23%23%23BIOC%23%23%23SOCI%23%23%23COMP%23%23%23HEAL%23%23%23AGRI%23%23%23ARTS&allLanguageClusterCategories=English%23%23%23Chinese%23%23%23Japanese%23%23%23German%23%23%23Spanish%23%23%23Polish%23%23%23French%23%23%23Portuguese%23%23%23Turkish%23%23%23Russian&allKeywordClusterCategories=Human%23%23%23Article%23%23%23Male%23%23%23Humans%23%23%23Female%23%23%23Autism%23%23%23Child%23%23%23Priority+journal%23%23%23Adult%23%23%23Controlled+study&allAffiliationClusterCategories=60011520%23%23%2360014439%23%23%2360007566%23%23%2360003915%23%23%2360025111%23%23%2360015481%23%23%2360027550%23%23%2360029929%23%23%2360016849%23%23%2360015278&allSourceTypeClusterCategories=j%23%23%23p%23%23%23d%23%23%23b%23%23%23k%23%23%23r%23%23%23Undefined&st1=asd&citedByJson=&extZone=&extOrigin=resultslist&originId=SC&selectedSources=&extSearchType=";
            CookieContainer tmpcook;
            var templist = new List<object>();
            templist = GET("http://www.scopus.com/");
            tmpcook = (CookieContainer) templist[1];
            string site = POST("http://www.scopus.com/search/submit/basic.url", datasite, tmpcook);
            OrderedDictionary datasite3 = paramaters(splitter(datasite2), parser(site));
            reczparam(ref datasite3, search);
            string filedata = fileadress(datasite3);
            Console.WriteLine("Pobieram plik");
            File.SaveFile("Scopus", search + ".bib", POST("http://www.scopus.com/results/handle.url", filedata, tmpcook));
            var structscop = new StructScop();
            structscop.Dodawanie(search, datafr, datato);
            _listscopus = structscop.StrScop;
            File.DeleteFile("Scopus", search + ".bib");
            BazyTh.Endthread(1);
        }

        private void reczparam(ref OrderedDictionary param, string search)
        {
            param.Remove("allSourceClusterCategories");
            param.Remove("allAuthorClusterCategories");
            param.Remove("allCountryClusterCategories");
            param.Remove("allYearClusterCategories");
            param.Remove("allDocTypeClusterCategories");
            param.Remove("allSubjectClusterCategories");
            param.Remove("allLanguageClusterCategories");
            param.Remove("allKeywordClusterCategories");
            param.Remove("allAffiliationClusterCategories");
            param.Remove("allSourceTypeClusterCategories");
            param["s"] = "TITLE-ABS-KEY%28" + search + "%29";
            param["refinedSearchString"] = "TITLE-ABS-KEY%28" + search + "%29";
            param["clickedLink"] = "export";
            param["origin"] = "resultslist";
            param["selectDeselectAllAttempt"] = "clicked";
            param["zone"] = "exportDropDown";
            param["view"] = "CiteAbsKeyws";
            int i;
            for (i = 0; i < param.Count; i++)
            {
                if (param[i].ToString() == "clicked")
                {
                    break;
                }
            }
            param.Insert(i + 1, "oneClickExport", "%7B%22Format%22%3A%22BIB%22%2C%22View%22%3A%22CiteAbsKeyws%22%7D");
        }
    }
}