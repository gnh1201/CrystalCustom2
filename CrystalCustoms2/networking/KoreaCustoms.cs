using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using CrystalCustoms2.controller;
using CrystalCustoms2.common;
using CrystalCustoms2.model.KoreaCustomsModel;
using LiteDB;

namespace CrystalCustoms2.networking
{
    class KoreaCustoms
    {
        static string commonUrl = "https://unipass.customs.go.kr:38010/ext/rest"; // 공통주소
        static Dictionary<string, string> requestUrls = new Dictionary<string, string>(); // 요청주소
        static Dictionary<string, object> paramPairs = new Dictionary<string, object>(); // 요청값

        // 화물통관 진행정보
        static public cargCsclPrgsInfoQryRtnVo retrieveCargCsclPrgsInfo(string info1, object info2)
        {
            // 요청결과 전달 방법 선언
            cargCsclPrgsInfoQryRtnVo ResponseResult = new cargCsclPrgsInfoQryRtnVo();

            // 요청 결과 담기
            Dictionary<string, object> rtnDict = new Dictionary<string, object>();
            string serviceName = "retrieveCargCsclPrgsInfo";
            string certKey = "";

            // 화물번호로 정보조회
            Dictionary<string, string[]> paramPair = new Dictionary<string, string[]>();
            paramPair.Add("cargMtNo", new string[] { "cargMtNo" }); // 화물관리번호
            paramPair.Add("mblNo", new string[] { "mblNo", "blYy" }); // 마스터 B/L
            paramPair.Add("hblNo", new string[] { "hblNo", "blYy" }); // 하우스 B/L

            if (!requestUrls.ContainsKey(serviceName)) {
                requestUrls.Add(serviceName, "cargCsclPrgsInfoQry/retrieveCargCsclPrgsInfo?crkyCn={certKey}");
                paramPairs.Add(serviceName, paramPair);
            }

            // 주소 조합
            Dictionary<string, string> reqParams = (Dictionary<string, string>)info2;
            string reqResource = requestUrls[serviceName];
            string[] paramNames = new string[] { };
            switch (info1)
            {
                case "cargMtNo":
                    paramNames = paramPair[info1]; break;
                case "mblNo":
                    paramNames = paramPair[info1]; break;
                case "hblNo":
                    paramNames = paramPair[info1]; break;
                default:
                    return null;
            }

            // 주소 합치기
            foreach (string paramName in paramNames)
            {
                reqResource += "&" + paramName + "={" + paramName + "}";
            }

            // 인증키 취득
            List<string> certKeys = OpApikeys.GetKeyByName(serviceName);
            if(certKeys.Count > 0)
            {
                certKey = certKeys.First();
            }

            // 자료요청
            RestClient client = new RestClient(commonUrl);
            RestRequest request = new RestRequest(reqResource, Method.GET);

            switch (info1)
            {
                case "cargMtNo":
                    request.AddUrlSegment("cargMtNo", reqParams["cargMtNo"]);
                    break;
                case "mblNo":
                    request.AddUrlSegment("mblNo", reqParams["mblNo"]);
                    request.AddUrlSegment("blYy", reqParams["blYy"]);
                    break;
                case "hblNo":
                    request.AddUrlSegment("hblNo", reqParams["hblNo"]);
                    request.AddUrlSegment("blYy", reqParams["blYy"]);
                    break;
                default:
                    return null;
            }
            request.AddUrlSegment("certKey", certKey);

            // 내용 불러오기
            IRestResponse response = client.Execute(request);
            string content = response.Content;

            // 파일 임시저장
            WriteTextFile.write(content);

            // XML을 클래스로 변환
            XmlSerializer serializer = new XmlSerializer(typeof(cargCsclPrgsInfoQryRtnVo));
            using (TextReader reader = new StringReader(content))
            {
                // 수입면장 정보 Mapping
                ResponseResult = (cargCsclPrgsInfoQryRtnVo)serializer.Deserialize(reader);

                // Api 참조 횟수 업데이트
                OpApikeys.UsedCountUp(serviceName);
            }
            
            // db에 저장
            using (var db = new LiteDatabase(@"cargCsclPrgsInfoQryRtnVo.db"))
            {
                var items = db.GetCollection<cargCsclPrgsInfoQryRtnVo>("cargCsclPrgsInfoQryRtnVo");
                var item = ResponseResult;
                items.Insert(item);
            }

            return ResponseResult;
        }
    }
}
