Shader "Unlit/ThermometerFillShader"
{
    Properties
    {
        _FillPercent ("Fill Percent", Range(0,1)) = 1
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolator
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _FillPercent;
            float4 _Color;

            Interpolator vert(MeshData v)
            {
                if (v.vertex.y >= 0.99)
                {
                    v.vertex.y -= 2 - _FillPercent * 2;
                }

                Interpolator o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(Interpolator i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}