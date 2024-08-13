Shader "Custom/Mandelbrot" {
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vertexProgram
            #pragma fragment fragmentProgram

            #include "UnityCG.cginc"

            struct VertexData {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            float _MaxWidth;
            float _Zoom;
            float _AspectRatio;
            float2 _CenterPoint;

            Interpolators vertexProgram (VertexData v) {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float w = _MaxWidth * _Zoom;
                float h = w / _AspectRatio;
                o.uv = v.uv * float2(w, h);
                o.uv -= float2(w * 0.5, h * 0.5) - _CenterPoint;
                return o;
            }

            float4 fragmentProgram (Interpolators i) : SV_Target {
                float2 val = i.uv;
                int count = 0;
                const int maxIterations = 500;
                while (abs(length(val)) < 2 && count < maxIterations) {
                    float2 newVal = float2(
                        val.x * val.x - val.y * val.y + i.uv.x,
                        2 * val.x * val.y + i.uv.y
                    );
                    val = newVal;
                    count++;
                }
                if (count == maxIterations) {
                    return float4(0, 0, 0, 1);
                }
                
                float iter = float(maxIterations);
                float r = count / iter;
                float g = (count * 2.0) / iter;
                g = g - floor(g) + 0.1;
                float b = (count * 4.0) / iter;
                b = b - floor(b) + 0.2;
                return float4(r, g, b, 1);
            }
            ENDCG
        }
    }
}
