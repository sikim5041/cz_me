using System;
using System.Windows.Forms;
using System.Data;

namespace cz
{
    /// <summary>
    /// TreeNodeEx에 대한 요약 설명입니다.
    /// </summary>
    public class TreeNodeEx : System.Windows.Forms.TreeNode
    {
        #region ▶ 사용자 정의 변수 선언
        /// <summary>
        /// 부서 코드
        /// </summary>
        private string m_Cddept = "";
        /// <summary>
        /// 부서명
        /// </summary>
        private string m_NmDept = "";
        /// <summary>
        /// 레벨
        /// </summary>
        private string m_Idtree = "";
        /// <summary>
        /// 상위 부서코드
        /// </summary>
        private string m_Hdept = "";
        /// <summary>
        /// 부서 순서
        /// </summary>
        private string m_Noorder = "";
        /// <summary>
        /// 더존 부서코드
        /// </summary>
        private string m_Dzcddept = "";
        /// <summary>
        /// 더존 부서명
        /// </summary>
        private string m_DznmDept = "";
        #endregion

        #region ▶ 필드 정의
        public string GetCddept
        {
            get
            {
                return m_Cddept;
            }
            set
            {
                m_Cddept = value;
            }
        }

        public string GetNoorder
        {
            get
            {
                return m_Noorder;
            }
            set
            {
                m_Noorder = value;
            }

        }
        public string GetNmDept
        {
            get
            {
                return m_NmDept;
            }
            set
            {
                m_NmDept = value;
            }
        }
        public string GetIdtree
        {
            get
            {
                return m_Idtree;
            }
            set
            {
                m_Idtree = value;
            }
        }
        public string GetHdept
        {
            get
            {
                return m_Hdept;
            }
            set
            {
                m_Hdept = value;
            }
        }
        public string GetDzcddept
        {
            get
            {
                return m_Dzcddept;
            }
            set
            {
                m_Dzcddept = value;
            }
        }
        public string GetDznmDept
        {
            get
            {
                return m_DznmDept;
            }
            set
            {
                m_DznmDept = value;
            }
        }
        #endregion

        #region ▶ 생성자
        /// <summary>
        /// 트리노드 생성자
        /// </summary>
        public TreeNodeEx()
        {

        }
        /// <summary>
        /// 최상위 노드
        /// </summary>
        public TreeNodeEx(string psNm)
        {
            m_NmDept = psNm;
            Text = psNm;
        }
        #endregion
    }
}
