﻿Shader "Hidden/BlackWhite"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);
                col.r = 0.299 * col.r + 0.587 * col.g + 0.114 * col.b;
                col.g = 0.2126 * col.r + 0.7152 * col.g + 0.0722 * col.b;
                col.b = 0.2627 * col.r + 0.6780 * col.g + 0.0593 * col.b;
                return col;
            }
            ENDCG
        }
    }
}