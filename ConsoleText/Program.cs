Console.WriteLine("체중(kg)를 입력하세요: (숫자만)");
float weight = float.Parse(Console.ReadLine());

Console.WriteLine("키(cm)를 입력하세요: (숫자만)");
float height = float.Parse(Console.ReadLine());
float m_height = height / 100;

float bmi = weight / (m_height * m_height);
Console.WriteLine("당신의 BMI: " + bmi);