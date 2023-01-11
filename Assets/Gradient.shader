Shader "Unlit/Gradient"
{
    Properties
    {
        _GradientColorOne("Gradient Color One: ", color) = (1,1,1,1)
        _GradientColorTwo("Gradient Color2 Two: ", color) = (1,1,1,1)
        _Denger("Denger: ", Range(0, 5.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : TEXCOORD1;
            };

            fixed4 _GradientColorOne;
            fixed4 _GradientColorTwo;
            fixed _Denger;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                //o.color = float4(v.uv, 0,0);
                o.color = lerp(_GradientColorOne, _GradientColorTwo, v.uv.y) * _Denger;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                return i.color ;
            }
            ENDCG
        }
    }
}
