CREATE VIEW ѡ������
AS
SELECT �γ�.�γ̺�,�γ���,�γ�.��ʦ��,����,Ժϵ,COUNT(ѡ��.�γ̺ţ�AS ѡ������
FROM ѡ�� RIGHT JOIN �γ� ON ѡ��.�γ̺�=�γ�.�γ̺�
      FULL JOIN ��ʦ ON �γ�.��ʦ��=��ʦ.��ʦ��
GROUP BY dbo.�γ�.�γ̺�,�γ���,�γ�.��ʦ��,����,Ժϵ