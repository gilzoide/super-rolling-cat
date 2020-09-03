Shader "Hidden/SnapToColorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            fixed4 _Color;
            
            #define PALETTE_WIDTH  4.0

            float4 luminosity_to_index(float x)
            {
                return floor(x * PALETTE_WIDTH);
            }
            
            float4 frag (v2f_img i) : SV_Target
            {
                float4 color = tex2D(_MainTex, i.uv);
                float grayscale = dot(color.rgb, float3(0.3, 0.59, 0.11)) * color.a;
                grayscale = luminosity_to_index(grayscale) / PALETTE_WIDTH;
                // return snap_to_palette(grayscale);
                return float4(grayscale, grayscale, grayscale, 1) * _Color;
            }
            ENDCG
        }
    }
}
